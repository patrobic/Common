using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using TestTools.Helper.Interfaces;

namespace TestTools.Helper
{
    public partial class TestHelper
    {
        public ITestHelper SetByte(byte[] resultFile, string name = null)
        {
            return SetResult(resultFile, name);
        }

        public ITestHelper SetPath(string path)
        {
            var file = File.ReadAllBytes(path);
            return SetResult(file, path);
        }

        public ITestHelper SetCsv<T>(IList<T> records, string name = null)
        {
            using var stream = new MemoryStream();
            using var csv = new CsvWriter(new StreamWriter(stream), GetCsvParameters());
            csv.WriteRecords(records);
            csv.Flush();
            var file = stream.ToArray();
            return SetResult(file, name);
        }

        public ITestHelper SetCsv<T>(IList<(IList<T> Records, string Name)> results)
        {
            foreach (var result in results)
            {
                SetCsv(result.Records, result.Name);
            }
            return this;
        }

        public ITestHelper SetJson<T>(T record, string name = null)
        {
            var file = Encoding.Default.GetBytes(JsonSerializer.Serialize(record, GetJsonParameters()));
            return SetResult(file, name);
        }

        public ITestHelper SetJson<T>(IList<(T Record, string Name)> results)
        {
            foreach (var result in results)
            {
                SetJson(result.Record, result.Name);
            }
            return this;
        }

        public ITestHelper SetString(string input, string name = null)
        {
            var file = Encoding.Default.GetBytes(input);
            return SetResult(file, name);
        }

        public ITestHelper SetByte(IList<byte[]> resultFiles, IList<string> names = null)
        {
            names ??= Enumerable.Range(1, resultFiles.Count()).Select(x => _pathHelper.FunctionName + "_" + x + Path.GetExtension(_pathHelper.FileName)).ToList();
            for (int i = 0; i < resultFiles.Count; i++)
            {
                SetResult(resultFiles[i], names[i]);
            }
            return this;
        }

        public ITestHelper SetByte(IList<(byte[] ResultFile, string Name)> results)
        {
            foreach (var result in results)
            {
                SetByte(result.ResultFile, result.Name);
            }
            return this;
        }

        public ITestHelper SetPath(string path, IList<string> names)
        {
            foreach (var file in names)
            {
                SetRelative(path, file);
            }
            return this;
        }

        public ITestHelper SetFolderPath(string path)
        {
            var fileNames = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (var file in fileNames)
            {
                var relPath = new Uri(path + "\\").MakeRelativeUri(new Uri(file)).ToString();
                SetRelative(path, relPath);
            }
            return this;
        }

        public ITestHelper SetByte(IList<byte[]> resultFiles, string name)
        {
            var names = Enumerable.Range(1, resultFiles.Count()).Select(x => _pathHelper.FunctionName + "_" + x + Path.GetExtension(_pathHelper.FileName)).ToList();
            return SetByte(resultFiles, names);
        }

        public ITestHelper SetRelative(string root, string rel)
        {
            var file = File.ReadAllBytes(Path.Combine(root, rel));
            return SetResult(file, rel);
        }
    }
}
