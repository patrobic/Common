using System.Collections.Generic;

namespace TestTools.Helper.Interfaces
{
    public interface ITestHelperCsv
    {
        /// <summary>
        /// 
        /// </summary>
        IList<T> GetCsv<T>(string path);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper SetCsv<T>(IList<T> records, string name = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertCsv<T>(IList<T> records, string name = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper SetCsv<T>(IList<(IList<T> Records, string Name)> results);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertCsv<T>(IList<(IList<T> Records, string Name)> results);
    }
}
