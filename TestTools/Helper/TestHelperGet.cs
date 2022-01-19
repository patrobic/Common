using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace TestTools.Helper
{
    public partial class TestHelper
    {
        public byte[] GetByte(string name = null)
        {
            GetPath(name);
            var sourceFile = File.ReadAllBytes(Path.Combine(_pathHelper.SourcePath, _pathHelper.FileName));
            return sourceFile;
        }

        public string GetPath(string name = null)
        {
            _pathHelper.FileName = name ?? _pathHelper.FunctionName + ".csv";
            return Path.Combine(_pathHelper.SourcePath, _pathHelper.FileName);
        }

        public IList<T> GetCsv<T>(string path)
        {
            var file = GetByte(path);
            return new CsvReader(new StreamReader(new MemoryStream(file)), GetCsvParameters()).GetRecords<T>().ToList();
        }

        public T GetJson<T>(string path)
        {
            var file = GetByte(path);
            return JsonSerializer.Deserialize<T>(file, GetJsonParameters());
        }

        public string GetString(string path)
        {
            var file = Encoding.Default.GetString(GetByte(path));
            return file;
        }

        public IList<byte[]> GetBytes(IList<string> names = null)
        {
            names ??= Directory.GetFiles(_pathHelper.SourcePath).Select(x => Path.GetFileName(x)).ToList();
            var sourceFiles = names.Select(x => GetByte(x)).ToList();
            return sourceFiles;
        }

        public IList<byte[]> GetBytes(string name)
        {
            return GetBytes(name, out _);
        }

        public IList<byte[]> GetBytes(string name, out List<string> fileNames)
        {
            var oldSourcePath = _pathHelper.SourcePath;
            _pathHelper.SourcePath = Path.Combine(_pathHelper.SourcePath, name);
            fileNames = Directory.GetFiles(_pathHelper.SourcePath).Select(x => Path.GetFileName(x)).ToList();
            var sourceFiles = GetBytes(fileNames);
            _pathHelper.SourcePath = oldSourcePath;
            return sourceFiles;
        }
    }
}
