using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Test.DataContext.Models.User;
namespace Planta_BackEnd.DataContext.Config.Identity
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(ur => new {ur.RoleId,ur.UserId});

            builder.ToTable(nameof(AppUserRole));
        }
    }
}
