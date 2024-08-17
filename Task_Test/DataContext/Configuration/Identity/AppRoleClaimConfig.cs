using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Test.DataContext.Models.User;

namespace Planta_BackEnd.DataContext.Config.Identity
{
    public class AppRoleClaimConfig : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.HasKey(rc => rc.Id);

            builder.Property(rc=>rc.ClaimType).HasMaxLength(128);
            builder.Property(rc=>rc.ClaimValue).HasMaxLength(128);

            builder.ToTable(nameof(AppRoleClaim));
        }
    }
}
