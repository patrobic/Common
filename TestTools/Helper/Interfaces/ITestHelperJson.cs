using System.Collections.Generic;

namespace TestTools.Helper.Interfaces
{
    public interface ITestHelperJson
    {
        /// <summary>
        /// 
        /// </summary>
        T GetJson<T>(string path);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper SetJson<T>(T record, string name = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertJson<T>(T record, string name = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper SetJson<T>(IList<(T Record, string Name)> results);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertJson<T>(IList<(T Record, string Name)> results);
    }
}
