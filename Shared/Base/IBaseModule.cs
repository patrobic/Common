using Shared.Context;
using Shared.Logger;
using Shared.ParameterManager;
using System;

namespace Shared.Base
{
    public abstract class IBaseModule : BaseLoggable
    {
        protected IContextFactory _context;
        protected IParameterManager _manager;

        public IBaseModule(string name, IContextFactory context, IParameterManager manager, ILogger logger)
            : base(name, logger)
        {
            _context = context;
            _manager = manager;
        }
    }

    public abstract class IBaseModule<TParameters> : IBaseModule
    {
        protected TParameters _parameters;

        public IBaseModule(string name, IContextFactory context, IParameterManager manager, ILogger logger)
            : base(name, context, manager, logger)
        {
        }

        protected void Run(TParameters parameters, Action func)
        {
            _parameters = parameters;
            var timer = Log(LogSource.Module);
            try
            {
                func.Invoke();
                Log(LogSource.Module, timer);
            }
            catch (Exception e)
            {
                Log(LogSource.Module, timer, e);
                throw;
            }
        }
    }

    public abstract class IBaseModule<TParameters, TOutput> : IBaseModule<TParameters>
        where TOutput : class?
    {
        public IBaseModule(string name, IContextFactory context, IParameterManager manager, ILogger logger)
            : base(name, context, manager, logger)
        {
        }

        protected TOutput? Run(TParameters parameters, Func<TOutput> func)
        {
            _parameters = parameters;
            var timer = Log(LogSource.Module);
            TOutput? result = null;
            try
            {
                result = func.Invoke();
            }
            catch (Exception e)
            {
                Log(LogSource.Module, timer, e);
                throw;
            }
            Log(LogSource.Module, timer);
            return result;
        }
    }
}
