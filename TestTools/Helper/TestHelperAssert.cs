using System.Collections.Generic;
using TestTools.Helper.Interfaces;

namespace TestTools.Helper
{
    public partial class TestHelper
    {
        public ITestHelper AssertByte(byte[] resultFile, string name = null)
        {
            return SetByte(resultFile, name).AssertFiles();
        }

        public ITestHelper AssertPath(string path)
        {
            return SetPath(path).AssertFiles();
        }

        public ITestHelper AssertCsv<T>(IList<T> records, string name = null)
        {
            return SetCsv(records, name).AssertFiles();
        }

        public ITestHelper AssertCsv<T>(IList<(IList<T> Records, string Name)> results)
        {
            return SetCsv(results).AssertFiles();
        }

        public ITestHelper AssertJson<T>(T record, string name = null)
        {
            return SetJson(record, name).AssertFiles();
        }

        public ITestHelper AssertJson<T>(IList<(T Record, string Name)> results)
        {
            return SetJson(results).AssertFiles();
        }

        public ITestHelper AssertString(string input, string name = null)
        {
            return SetString(input, name).AssertFiles();
        }

        public ITestHelper AssertByte(IList<byte[]> resultFiles, IList<string> names = null)
        {
            return SetByte(resultFiles, names).AssertFiles();
        }

        public ITestHelper AssertByte(IList<(byte[] ResultFile, string Name)> results)
        {
            return SetByte(results).AssertFiles();
        }

        public ITestHelper AssertPath(string path, IList<string> names)
        {
            return SetPath(path, names).AssertFiles();
        }

        public ITestHelper AssertFolderPath(string path)
        {
            return SetFolderPath(path).AssertFiles();
        }

        public ITestHelper AssertByte(IList<byte[]> resultFiles, string name)
        {
            return SetByte(resultFiles, name).AssertFiles();
        }
    }
}
