using System.Reflection;
using TestTools.Helper.Interfaces;

namespace TestTools.PathHelper
{
    public interface ITestPathHelper
    {
        static string FolderName { get; set; }
        string FileName { get; set; }
        string FunctionName { get; set; }

        string InputPath { get; set; }
        string OutputPath { get; set; }
        string ExpectedPath { get; set; }

        void Initialize(MethodBase caller, TestFileLevel fileLevel = TestFileLevel.Namespace, string path = null, NamespaceMode mode = NamespaceMode.Project);
    }
}