namespace Framework
{
    public interface IContextFactory
    {
        public IDatabaseContext Create();
    }
}
