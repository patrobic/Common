namespace Shared.Context
{
    public interface IContextFactory
    {
        public BaseDatabaseContext Create();
    }
}
