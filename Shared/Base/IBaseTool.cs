using Shared.Logger;
using System;

namespace Book.Base
{
    public abstract class IBaseTool<TParameters> : BaseLoggable
    {
        protected TParameters _parameters;

        public IBaseTool(ILogger logger)
            : base(logger)
        {
        }
    }

    public abstract class IBaseTool<TParameters, TInput> : BaseLoggable
    {
        protected TParameters _parameters;

        public IBaseTool(ILogger logger)
            : base(logger)
        {
        }

        protected void Run(TParameters parameters, Action<TInput> func, TInput input1)
        {
            _parameters = parameters;
            var timer = Log(LogSource.Tool);
            try
            {
                func.Invoke(input1);
            }
            catch (Exception e)
            {
                Log(LogSource.Tool, timer, e);
            }
            Log(LogSource.Tool, timer);
        }
    }

    public abstract class IBaseToolOut<TParameters, TOutput> : BaseLoggable
        where TOutput : class?
    {
        protected TParameters _parameters;

        public IBaseToolOut(ILogger logger)
            : base(logger)
        {
        }

        protected TOutput Run(TParameters parameters, Func<TOutput> func)
        {
            _parameters = parameters;
            var timer = Log(LogSource.Tool);
            TOutput? result = null;
            try
            {
                result = func.Invoke();
            }
            catch (Exception e)
            {
                Log(LogSource.Tool, timer, e);
            }
            Log(LogSource.Tool, timer);
            return result;
        }
    }

    public abstract class IBaseToolOut<TParameters, TInput, TOutput> : IBaseTool<TParameters>
        where TOutput : class?
    {
        public IBaseToolOut(ILogger logger)
            : base(logger)
        {
        }

        protected TOutput? Run(TParameters parameters, Func<TInput, TOutput> func, TInput input)
        {
            _parameters = parameters;
            var timer = Log(LogSource.Tool);
            TOutput? result = null;
            try
            {
                result = func.Invoke(input);
            }
            catch (Exception e)
            {
                Log(LogSource.Tool, timer, e);
            }
            Log(LogSource.Tool, timer);
            return result;
        }
    }

    public abstract class IBaseTool<TParameters, TInput1, TInput2> : IBaseTool<TParameters>
    {
        public IBaseTool(ILogger logger)
            : base(logger)
        {
        }

        protected void Run(TParameters parameters, Action<TInput1, TInput2> func, TInput1 input1, TInput2 input2)
        {
            _parameters = parameters;
            var timer = Log(LogSource.Tool);
            try
            {
                func.Invoke(input1, input2);
            }
            catch (Exception e)
            {
                Log(LogSource.Tool, timer, e);
            }
            Log(LogSource.Tool, timer);
        }
    }

    public abstract class IBaseToolOut<TParameters, TInput1, TInput2, TOutput> : IBaseTool<TParameters>
        where TOutput : class?
    {
        public IBaseToolOut(ILogger logger)
            : base(logger)
        {
        }

        protected TOutput? Run(TParameters parameters, Func<TInput1, TInput2, TOutput> func, TInput1 input1, TInput2 input2)
        {
            _parameters = parameters;
            var timer = Log(LogSource.Tool);
            TOutput? result = null;
            try
            {
                result = func.Invoke(input1, input2);
            }
            catch (Exception e)
            {
                Log(LogSource.Tool, timer, e);
            }
            Log(LogSource.Tool, timer);
            return result;
        }
    }
}
