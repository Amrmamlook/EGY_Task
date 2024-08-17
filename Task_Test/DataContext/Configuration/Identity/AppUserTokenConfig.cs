using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Test.DataContext.Models.User;


namespace Planta_BackEnd.DataContext.Config.Identity
{
    public class AppUserTokenConfig : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            builder.HasKey(ut=>new {ut.UserId,ut.LoginProvider,ut.Name});

            builder.ToTable(nameof(AppUserToken));

            builder.Property(ut => ut.LoginProvider).HasMaxLength(128);
            builder.Property(ut => ut.Name).HasMaxLength(128);
            //builder.Property(ut=>ut.Value).HasMaxLength(500);

            builder.HasOne<AppUser>().WithMany().HasForeignKey(ut=>ut.UserId);

        }
    }
}
