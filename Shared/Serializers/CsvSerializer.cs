using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Shared.Serializers
{
    public static class CsvSerializer
    {
        public static byte[] Serialize<TType>(IList<TType> records, string path = null)
        {
            return Serialize(records, null, path);
        }

        public static byte[] Serialize<TType>(IList<TType> records, ClassMap<TType> mapping, string path = null)
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            if (mapping != null)
            {
                csv.Context.RegisterClassMap(mapping);
            }
            csv.WriteRecords(records);
            csv.Flush();
            var file = stream.ToArray();

            if (path != null)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllBytes(path, file);
            }

            return file;
        }

        public static byte[] Serialize<TMap, TTemplate>(IList<TTemplate> records, string path = null)
            where TMap : ClassMap<TTemplate>
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<TMap>();
            csv.WriteRecords(records);
            csv.Flush();
            var file = stream.ToArray();

            if (path != null)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllBytes(path, file);
            }

            return file;
        }
    }
}
