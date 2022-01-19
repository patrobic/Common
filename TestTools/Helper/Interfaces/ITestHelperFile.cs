namespace TestTools.Helper.Interfaces
{
    public interface ITestHelperFile
    {
        /// <summary>
        /// use default file name if name is null.
        /// </summary>
        byte[] GetByte(string name = null);
        /// <summary>
        /// take provided file as result with optional name.
        /// </summary>
        ITestHelper SetByte(byte[] resultFile, string name = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertByte(byte[] resultFile, string name = null);
    }
}
