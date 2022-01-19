using Framework;
using Shared.Logger;
using Shared.ParameterManager;

namespace Book.Base
{
    public abstract class BaseModule<TParameters> : IBaseModule<TParameters>
    {
        public BaseModule(string name, IContextFactory context, IParameterManager manager, ILogger logger)
            : base(name, context, manager, logger)
        {
        }

        public void Run(TParameters parameters)
        {
            Run(parameters, Execute);
        }

        protected abstract void Execute();
    }

    public abstract class BaseModule<TParameters, TOutput> : IBaseModule<TParameters, TOutput>
        where TOutput : class?
    {
        public BaseModule(string name, IContextFactory context, IParameterManager manager, ILogger logger)
            : base(name, context, manager, logger)
        {
        }

        public TOutput? Run(TParameters parameters)
        {
            return Run(parameters, Execute);
        }

        protected abstract TOutput Execute();
    }
}
