using System.Reflection;
using TestTools.Helper.Interfaces;

namespace TestTools.PathHelper
{
    public interface ITestPathHelper
    {
        static string FolderName { get; set; }
        string FileName { get; set; }
        string FunctionName { get; set; }

        string SourcePath { get; set; }
        string ResultPath { get; set; }
        string ReferencePath { get; set; }

        void Initialize(MethodBase caller, TestFileLevel fileLevel = TestFileLevel.Namespace, string path = null, NamespaceMode mode = NamespaceMode.Project);
    }
}