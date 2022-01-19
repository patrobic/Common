using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Framework
{
    public abstract class IDatabaseContext : IdentityDbContext
    {
        public IDatabaseContext()
            : base()
        {
        }
    }
}
