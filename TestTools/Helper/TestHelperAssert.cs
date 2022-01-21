using System.Collections.Generic;
using TestTools.Helper.Interfaces;

namespace TestTools.Helper
{
    public partial class TestHelper
    {
        public ITestHelper AssertByte(byte[] resultFile, string name = null)
        {
            return SetByte(resultFile, name).Assert();
        }

        public ITestHelper AssertPath(string path)
        {
            return SetPath(path).Assert();
        }

        public ITestHelper AssertCsv<T>(IList<T> records, string name = null)
        {
            return SetCsv(records, name).Assert();
        }

        public ITestHelper AssertCsv<T>(IList<(IList<T> Records, string Name)> results)
        {
            return SetCsv(results).Assert();
        }

        public ITestHelper AssertJson<T>(T record, string name = null)
        {
            return SetJson(record, name).Assert();
        }

        public ITestHelper AssertJson<T>(IList<(T Record, string Name)> results)
        {
            return SetJson(results).Assert();
        }

        public ITestHelper AssertString(string input, string name = null)
        {
            return SetString(input, name).Assert();
        }

        public ITestHelper AssertByte(IList<byte[]> resultFiles, IList<string> names = null)
        {
            return SetByte(resultFiles, names).Assert();
        }

        public ITestHelper AssertByte(IList<(byte[] ResultFile, string Name)> results)
        {
            return SetByte(results).Assert();
        }

        public ITestHelper AssertPath(string path, IList<string> names)
        {
            return SetPath(path, names).Assert();
        }

        public ITestHelper AssertFolderPath(string path)
        {
            return SetFolderPath(path).Assert();
        }

        public ITestHelper AssertByte(IList<byte[]> resultFiles, string name)
        {
            return SetByte(resultFiles, name).Assert();
        }
    }
}
