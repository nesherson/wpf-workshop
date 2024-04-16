using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WPF.FileApp
{
    public static class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives() =>
            Directory
            .GetLogicalDrives()
            .Select(x => new DirectoryItem() { FullPath = x, Type = DirectoryItemType.Drive })
            .ToList();

        public static List<DirectoryItem> GetDirectoryContent(string fullPath)
        {
            var items = new List<DirectoryItem>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                var fs = Directory.GetFiles(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(x => new DirectoryItem { FullPath = x, Type = DirectoryItemType.Folder }));

                if (fs.Length > 0)
                    items.AddRange(fs.Select(x => new DirectoryItem { FullPath = x, Type = DirectoryItemType.File }));
            }
            catch
            {
                //Ignore
            }

            return items;
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
                return path;

            return normalizedPath.Substring(lastIndex + 1);
        }
    }
}