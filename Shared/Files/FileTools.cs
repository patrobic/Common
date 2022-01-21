using System.Collections.Generic;
using System.IO;

namespace Shared.Files
{
    public static class FileTools
    {
        public static void EmptyDirectory(string path)
        {
            var di = new DirectoryInfo(path);
            foreach (var file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (var dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static void SaveFiles(IList<BaseOutputFile> files, string path)
        {
            foreach (var file in files)
            {
                var directory = Path.Combine(path, file.Path);
                try
                {
                    Directory.CreateDirectory(directory);
                    File.WriteAllBytes(Path.Combine(directory, file.Name), file.Data);
                }
                catch { }
            }
        }
    }
}
