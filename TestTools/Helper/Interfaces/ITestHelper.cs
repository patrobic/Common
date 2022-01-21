using System.Reflection;
using TestTools.Comparators;

namespace TestTools.Helper.Interfaces
{
    public interface ITestHelper : ITestHelperFile, ITestHelperFiles, ITestHelperCsv, ITestHelperString, ITestHelperPath, ITestHelperJson
    {
        /// <summary>
        /// 
        /// </summary>
        ITestHelper Initialize(MethodBase caller);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper Initialize(MethodBase caller, TestFileLevel fileLevel = TestFileLevel.Namespace, string path = null, float? marginOfError = null, IFileComparator comparator = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper Initialize(MethodBase caller, float? marginOfError = null, IFileComparator comparator = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper Assert();
    }
}
