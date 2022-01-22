using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shared.Context
{
    public interface IContextFactory
    {
        public string ConnectionString { get; set; }

        public IdentityDbContext Create();
    }
}
