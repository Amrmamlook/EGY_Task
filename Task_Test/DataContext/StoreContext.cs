using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Task_Test.DataContext
{
    public class StoreContext(DbContextOptions<StoreContext> options) :
        IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
        }
    }
}
