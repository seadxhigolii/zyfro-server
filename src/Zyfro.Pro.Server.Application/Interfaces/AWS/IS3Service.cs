using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Application.Interfaces.AWS
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file, string key);
        Task<byte[]> DownloadFileAsync(string key);
        Task DeleteFileAsync(string key);
        Task<bool> SetObjectTagsAsync(string fileKey, Dictionary<string, string> tags);
    }

}
