using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using TestTools.Comparators;
using TestTools.Helper.Interfaces;
using TestTools.PathHelper;
using Xunit.Abstractions;

namespace TestTools.Helper
{
    public partial class TestHelper : ITestHelper
    {
        protected ITestPathHelper _pathHelper = new TestPathHelper();
        protected IFileComparator _comparator = new BinaryComparator();
        protected float _marginOfError = 0.002f;
        private ITestOutputHelper _output;
        private string _errorLog = string.Empty;
        private string _infoLog = string.Empty;

        public TestHelper(ITestOutputHelper output)
        {
            _output = output;
        }

        public ITestHelper Initialize(MethodBase caller)
        {
            _pathHelper.Initialize(caller);
            SetPathInfo();
            return this;
        }

        public ITestHelper Assert()
        {
            if (_infoLog.Length > 0)
            {
                _output.WriteLine(_infoLog);
            }
            if (_errorLog.Length > 0)
            {
                _output.WriteLine(_errorLog);
            }
            Xunit.Assert.True(_errorLog.Length == 0);
            return this;
        }

        public ITestHelper Initialize(MethodBase caller, TestFileLevel fileLevel, string path = null, float? marginOfError = null, IFileComparator comparator = null)
        {
            if (marginOfError != null)
            {
                _marginOfError = marginOfError.Value;
            }
            if (comparator != null)
            {
                _comparator = comparator;
            }
            _pathHelper.Initialize(caller, fileLevel, path);
            SetPathInfo();
            return this;
        }

        public ITestHelper Initialize(MethodBase caller, float? marginOfError = null, IFileComparator comparator = null)
        {
            if (marginOfError != null)
            {
                _marginOfError = marginOfError.Value;
            }
            if (comparator != null)
            {
                _comparator = comparator;
            }
            _pathHelper.Initialize(caller);
            SetPathInfo();
            return this;
        }

        private void SetPathInfo()
        {
            _infoLog += $"Source:    {_pathHelper.InputPath}\n";
            _infoLog += $"Result:    {_pathHelper.OutputPath}\n";
            _infoLog += $"Reference: {_pathHelper.ExpectedPath}\n";
        }

        public ITestHelper SetResult(byte[] resultFile, string name = null)
        {
            var fileName = (name == null) ? _pathHelper.FileName : (name.Contains('.') ? name : (_pathHelper.FunctionName + "." + name));

            var resultPath = Path.Combine(_pathHelper.OutputPath, fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(resultPath));
            File.WriteAllBytes(resultPath, resultFile);

            var referencePath = Path.Combine(_pathHelper.ExpectedPath, fileName);
            if (!File.Exists(referencePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(referencePath));
                File.Copy(resultPath, referencePath);

                _errorLog += $"File {name} did not exist, created it in Reference (run test again).\n";
                return this;
            }
            var referenceFile = File.ReadAllBytes(Path.Combine(_pathHelper.ExpectedPath, fileName));

            var equal = _comparator.Compare(referenceFile, resultFile, _marginOfError, out float diffRatio);
            if (!equal)
            {
                _errorLog += $"File {name} is too different ({diffRatio} > {_marginOfError}).\n";
                return this;
            }
            return this;
        }

        private CsvConfiguration GetCsvParameters()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                IgnoreReferences = true,
            };
        }

        private JsonSerializerOptions GetJsonParameters()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }
    }
}
