using Shared.Context;
using Shared.ParameterManager;
using Xunit.Abstractions;

namespace TestTools.Base
{
    public abstract class BaseContextTest<TContextFactory, TParameters> : BaseContextTest<TContextFactory>
        where TContextFactory : IContextFactory, new()
    {
        protected TParameters _parameters;

        public BaseContextTest(TParameters parameters, ITestOutputHelper output, string connection = null)
           : base(output, connection)
        {
            _parameters = parameters;
        }
    }

    public abstract class BaseContextTest<TContextFactory> : BaseTest
        where TContextFactory : IContextFactory, new()
    {
        protected IContextFactory _context;
        protected ParameterManager _manager;

        public BaseContextTest(ITestOutputHelper output, string connection = null)
           : base(output)
        {
            _context = new TContextFactory();
            if (connection != null)
            {
                _context.ConnectionString = connection;
            }
        }
    }
}
