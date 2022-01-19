namespace TestTools.Helper.Interfaces
{
    public interface ITestHelperPath
    {
        /// <summary>
        /// 
        /// </summary>
        string GetPath(string name = null);
        /// <summary>
        /// take file at file path (existing on disk) as the result.
        /// </summary>
        ITestHelper SetPath(string path);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertPath(string path);
    }
}
