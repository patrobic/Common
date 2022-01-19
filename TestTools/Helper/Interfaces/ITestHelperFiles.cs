using System.Collections.Generic;

namespace TestTools.Helper.Interfaces
{
    public interface ITestHelperFiles
    {
        /// <summary>
        /// load all files in default directory if names is null.
        /// </summary>
        IList<byte[]> GetBytes(IList<string> names = null);
        /// <summary>
        /// 
        /// </summary>
        IList<byte[]> GetBytes(string name);
        /// <summary>
        /// load all files in specified directory name if name is not null and singular.
        /// </summary>
        IList<byte[]> GetBytes(string name, out List<string> fileNames);
        /// <summary>
        /// generate default numbered names if names is null.
        /// </summary>
        ITestHelper SetByte(IList<byte[]> resultFiles, IList<string> names = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper SetByte(IList<(byte[] ResultFile, string Name)> results);
        /// <summary>
        /// take named files at a folder path (existing on disk) as the result.
        /// </summary>
        ITestHelper SetPath(string path, IList<string> names);
        /// <summary>
        /// take all files at a folder path (existing on disk) as the result.
        /// </summary>
        ITestHelper SetFolderPath(string path);
        /// <summary>
        /// generate numbered names with specified prefix name, when name is not null and singular.
        /// </summary>
        ITestHelper SetByte(IList<byte[]> resultFiles, string name);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertByte(IList<byte[]> resultFiles, IList<string> names = null);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertByte(IList<(byte[] ResultFile, string Name)> results);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertPath(string path, IList<string> names);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertFolderPath(string path);
        /// <summary>
        /// 
        /// </summary>
        ITestHelper AssertByte(IList<byte[]> resultFiles, string name);
    }
}
