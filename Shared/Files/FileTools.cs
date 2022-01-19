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

    }
}
