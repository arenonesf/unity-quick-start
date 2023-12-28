using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace arenonesf
{
    public static class QuickStart
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            Folders.CreateDirectories("_Project", "Scripts", "Art", "Prefabs", "ScriptableObjects");
            Refresh();
        }

        [MenuItem("Tools/Setup/Load New Manifest")]
        private static async void LoadNewManifest()
        {
            await Packages.ReplacePackagesFromGist("28fb082695626200c7350fb2f92589ba");
        }
    }
}
