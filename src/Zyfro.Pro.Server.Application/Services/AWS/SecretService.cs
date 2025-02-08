using Zyfro.Pro.Server.Application.Interfaces.AWS;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Threading.Tasks;
using System;
using Amazon.SecretsManager.Model.Internal.MarshallTransformations;
namespace Zyfro.Pro.Server.Application.Services.AWS
{   
    public class SecretService : ISecretService
    {
        public async Task<string> GetSecret()
        {
            string secretName = "zyfro/AWS/S3";
            string region = "eu-north-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };

            GetSecretValueResponse response;
            
            response = await client.GetSecretValueAsync(request);

            string secret = response.SecretString;

            return secret;
        }
    }
    
}
