using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Test.DataContext.Models.User;

namespace Planta_BackEnd.DataContext.Config.Identity
{
    public class AppUserClaimConfig : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.HasKey(uc => uc.Id);

            builder.Property(uc=>uc.ClaimType).HasMaxLength(128);
            builder.Property(uc=>uc.ClaimValue).HasMaxLength(128);  



            builder.ToTable(nameof(AppUserClaim));
        }
    }
}
