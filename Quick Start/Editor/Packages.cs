using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace arenonesf
{
    public static class Packages
    {
        public static async Task ReplacePackagesFromGist(string id, string user = "arenonesf")
        {
            var url = GetGistUrl(id, user);
            var content = await GetFileContent(url);
            ReplacePackageFile(content);
        }

        private static string GetGistUrl(string id, string user) 
            => $"https://gist.githubusercontent.com/{user}/{id}/raw";

        private static async Task<string> GetFileContent(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private static void ReplacePackageFile(string content)
        {
            var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, content);
            UnityEditor.PackageManager.Client.Resolve();
        }
    }
}