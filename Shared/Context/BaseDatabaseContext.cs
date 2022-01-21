using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shared.Context
{
    public abstract class BaseDatabaseContext : IdentityDbContext
    {
        public BaseDatabaseContext()
            : base()
        {
        }
    }
}
