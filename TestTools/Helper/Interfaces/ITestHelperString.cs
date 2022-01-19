namespace TestTools.Helper.Interfaces
{
    public interface ITestHelperString
    {
        /// <summary>
        /// 
        /// </summary>
        string GetString(string path);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper SetString(string input, string name = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertString(string input, string name = null);
    }
}
