using Shared.Logger;

namespace Shared.Base
{
    public abstract class BaseTool<TParameters, TInput> : IBaseTool<TParameters, TInput>
    {
        public BaseTool(ILogger logger)
            : base(logger)
        {
        }

        public void Run(TParameters parameters, TInput input)
        {
            Run(parameters, Execute, input);
        }

        protected abstract void Execute(TInput input);
    }

    public abstract class BaseToolOut<TParameters, TOutput> : IBaseToolOut<TParameters, TOutput>
        where TOutput : class?
    {
        public BaseToolOut(ILogger logger)
            : base(logger)
        {
        }

        public TOutput? Run(TParameters parameters)
        {
            return Run(parameters, Execute);
        }

        protected abstract TOutput Execute();
    }

    public abstract class BaseToolOut<TParameters, TInput, TOutput> : IBaseToolOut<TParameters, TInput, TOutput>
        where TOutput : class?
    {
        public BaseToolOut(ILogger logger)
            : base(logger)
        {
        }

        public TOutput? Run(TParameters parameters, TInput input)
        {
            return Run(parameters, Execute, input);
        }

        protected abstract TOutput Execute(TInput input);
    }

    public abstract class BaseTool<TParameters, TInput1, TInput2> : IBaseTool<TParameters, TInput1, TInput2>
    {
        public BaseTool(ILogger logger)
            : base(logger)
        {
        }

        public void Run(TParameters parameters, TInput1 input1, TInput2 input2)
        {
            Run(parameters, Execute, input1, input2);
        }

        protected abstract void Execute(TInput1 input1, TInput2 input2);
    }

    public abstract class BaseToolOut<TParameters, TInput1, TInput2, TOutput> : IBaseToolOut<TParameters, TInput1, TInput2, TOutput>
        where TOutput : class?
    {
        public BaseToolOut(ILogger logger)
            : base(logger)
        {
        }

        public TOutput? Run(TParameters parameters, TInput1 input1, TInput2 input2)
        {
            return Run(parameters, Execute, input1, input2);
        }

        protected abstract TOutput Execute(TInput1 input1, TInput2 input2);
    }
}
