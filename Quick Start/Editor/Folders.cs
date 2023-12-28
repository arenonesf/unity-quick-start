using System.IO;
using UnityEngine;
using static System.IO.Path;

namespace arenonesf
{
    public static class Folders
    {
        public static void CreateDirectories(string root, params string[] directories)
        {
            var fullPath = Combine(Application.dataPath, root);
            foreach (var newDirectory in directories) Directory.CreateDirectory(Combine(fullPath, newDirectory));
        }
    }
}