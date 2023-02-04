using Shared.Logger;
using TestTools.Helper;
using TestTools.Helper.Interfaces;
using Xunit.Abstractions;

namespace TestTools.Base
{
    public abstract class BaseTest<TParameters> : BaseTest
    {
        protected TParameters _parameters;
        public BaseTest(TParameters parameters, ITestOutputHelper output)
            : base(output)
        {
            _parameters = parameters;
        }
    }

    public abstract class BaseTest
    {
        protected readonly ITestOutputHelper _output;

        public BaseTest(ITestOutputHelper output)
        {
            _output = output;
            _helper = new TestHelper(output);
        }

        protected ILogger _logger = new Logger(null, new LoggerParameters());
        protected ITestHelper _helper;
    }
}
