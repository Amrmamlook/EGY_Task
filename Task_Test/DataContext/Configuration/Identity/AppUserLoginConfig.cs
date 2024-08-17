using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Test.DataContext.Models.User;

namespace Planta_BackEnd.DataContext.Config.Identity
{
    public class AppUserLoginConfig : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

            builder.ToTable(nameof(AppUserLogin));

            builder.Property(ul=>ul.LoginProvider).HasMaxLength(128);
            builder.Property(ul=>ul.ProviderKey).HasMaxLength(128);
            builder.Property(ul => ul.ProviderDisplayName).HasMaxLength(256);
        }
    }
}
