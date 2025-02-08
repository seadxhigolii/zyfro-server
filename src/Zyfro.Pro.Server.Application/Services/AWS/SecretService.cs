using Zyfro.Pro.Server.Application.Interfaces.AWS;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Threading.Tasks;
using System;
using Amazon.SecretsManager.Model.Internal.MarshallTransformations;
using Newtonsoft.Json;
namespace Zyfro.Pro.Server.Application.Services.AWS
{   
    public class SecretService : ISecretService
    {
        public async Task<(string accessKey, string secretKey)> GetSecret()
        {
            string secretName = "s3secret";
            string region = "eu-north-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };

            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving secret: {ex.Message}");
                throw;
            }

            if (response.SecretString != null)
            {
                var secretJson = JsonConvert.DeserializeObject<dynamic>(response.SecretString);
                string accessKey = secretJson["AWS:S3:AccessKey"];
                string secretKey = secretJson["AWS:S3:SecretKey"];
                return (accessKey, secretKey);
            }

            throw new Exception("Secret is stored in binary format, which is not supported in this implementation.");
        }
    }
    
}
