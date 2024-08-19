using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Task_Test.DataContext
{
    public class StoreContext(DbContextOptions<StoreContext> options) :
        IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>(options)
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<UserPhone> UserPhone { get; set; }
        public DbSet<Calls> Calls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
        }
    }
}
