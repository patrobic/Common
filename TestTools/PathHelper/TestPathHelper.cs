using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TestTools.Helper.Interfaces;

namespace TestTools.PathHelper
{
    public class TestPathHelper : ITestPathHelper
    {
        private string _className;
        private string _namespaceName;
        private string _relativePath;

        private string _inputPath;
        private string _outputPath;
        private string _expectedPath;

        public static string FolderName { get; set; }

        public string FileName { get; set; }

        public string FunctionName { get; set; }

        public string InputPath { get; set; }

        public string OutputPath { get; set; }

        public string ExpectedPath { get; set; }

        public TestPathHelper(
            string relativePath = "../../../../Data/TestData",
            string inputPath = "Source",
            string outputPath = "Result",
            string expectedPath = "Reference")
        {
            _relativePath = relativePath;
            _inputPath = inputPath;
            _outputPath = outputPath;
            _expectedPath = expectedPath;
        }

        public void Initialize(MethodBase caller, TestFileLevel fileLevel = TestFileLevel.Root, string path = null, NamespaceMode mode = NamespaceMode.Project)
        {
            FunctionName = caller.Name;
            _className = caller.DeclaringType.Name;

            var split = caller.DeclaringType.Namespace.Split('.');

            _namespaceName = mode switch
            {
                NamespaceMode.Full => caller.DeclaringType.Namespace,
                NamespaceMode.Project => string.Join("/", split.TakeLast(split.Length - 2)),
                NamespaceMode.Last => split.Last(),
                _ => throw new NotImplementedException(),
            };

            if (FolderName == null)
            {
                FolderName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            }

            var rootPath = Path.GetFullPath(_relativePath, Directory.GetCurrentDirectory());

            var sourcePath = fileLevel switch
            {
                TestFileLevel.Test => Path.Combine(_inputPath, _namespaceName, _className, FunctionName),
                TestFileLevel.Class => Path.Combine(_inputPath, _namespaceName, _className),
                TestFileLevel.Namespace => Path.Combine(_inputPath, _namespaceName),
                TestFileLevel.Root => Path.Combine(_inputPath),
                _ => throw new NotImplementedException(),
            };

            InputPath = Path.Combine(rootPath, sourcePath).Replace('\\', '/');
            if (path != null)
            {
                InputPath = Path.IsPathFullyQualified(path) ? path : Path.GetFullPath(Path.Combine(rootPath, sourcePath, path));
            }

            OutputPath = Path.Combine(rootPath, _outputPath, _namespaceName, _className, FolderName, FunctionName).Replace('\\', '/');
            ExpectedPath = Path.Combine(rootPath, _expectedPath, _namespaceName, _className, FunctionName).Replace('\\', '/');
        }
    }
}
