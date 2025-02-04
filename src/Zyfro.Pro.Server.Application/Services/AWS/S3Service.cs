using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Application.Interfaces.AWS;

namespace Zyfro.Pro.Server.Application.Services.AWS
{
    internal class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3Service(IConfiguration configuration)
        {
            var awsOptions = configuration.GetSection("AWS");
            _s3Client = new AmazonS3Client(awsOptions["AccessKey"], awsOptions["SecretKey"], Amazon.RegionEndpoint.GetBySystemName(awsOptions["Region"]));
            _bucketName = awsOptions["BucketName"];
        }

        public async Task<string> UploadFileAsync(IFormFile file, string key)
        {
            using var stream = file.OpenReadStream();
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = key,
                InputStream = stream,
                ContentType = file.ContentType
            };

            var response = await _s3Client.PutObjectAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK
                ? $"https://{_bucketName}.s3.amazonaws.com/{key}"
                : throw new Exception("Upload failed");
        }

        public async Task<byte[]> DownloadFileAsync(string key)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            using var response = await _s3Client.GetObjectAsync(request);
            using var memoryStream = new MemoryStream();
            await response.ResponseStream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public async Task DeleteFileAsync(string key)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            await _s3Client.DeleteObjectAsync(request);
        }
    }
}
