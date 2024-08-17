using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Test.DataContext.Models.User;

namespace Planta_BackEnd.DataContext.Config.Identity
{
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(r => r.Id);

            builder.ToTable(nameof(AppRole));

            builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleIndex");

            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            builder.Property(r => r.Name).HasMaxLength(256);
            builder.Property(r=>r.NormalizedName).HasMaxLength(256);
            builder.Property(r=>r.ConcurrencyStamp).HasMaxLength(50);

            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(r => r.RoleId).IsRequired();
            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            builder.HasData(
				new AppRole() { Id = 1, Name = "Client", NormalizedName = "CLIENT", ConcurrencyStamp = Guid.NewGuid().ToString() }, 
				new AppRole() { Id = 2, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() }, 
                new AppRole() { Id = 3, Name = "SubAdmin", NormalizedName = "SUBADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() }); 
        }
    }
}
