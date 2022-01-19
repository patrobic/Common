using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Shared.Files
{
    public static class ZipTool
    {
        public static byte[] Zip(IList<BaseOutputFile> files)
        {
            using var compressed = new MemoryStream();
            using var zipArchive = new ZipArchive(compressed, ZipArchiveMode.Create, false);

            foreach (var file in files)
            {
                var path = Path.Combine(file.Path, file.Name);
                var zipEntry = zipArchive.CreateEntry(path, CompressionLevel.Optimal);

                using var original = new MemoryStream(file.Data);
                using var zipEntryStream = zipEntry.Open();
                original.CopyTo(zipEntryStream);
            }

            zipArchive.Dispose();
            var data = compressed.ToArray();
            return data;
        }
    }
}
