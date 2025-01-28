using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Common.Helpers
{
    public class EmbeddedResourceHelper
    {
        private static Assembly _currentAssembly = Assembly.GetExecutingAssembly();

        public static void ForAssembly(Assembly assembly) => _currentAssembly = assembly;

        public async static Task<T> JsonFileDeserializeAsync<T>(string fileName)
        {
            var resources = _currentAssembly.GetManifestResourceNames();

            using Stream stream = _currentAssembly.GetManifestResourceStream(resources.First(x => x.Contains(fileName)));

            using StreamReader reader = new(stream);

            return JsonConvert.DeserializeObject<T>(await reader.ReadToEndAsync());
        }
    }
}
