using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Test.DataContext.Models.User;

namespace Task_Test.DataContext.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable(nameof(AppUser));


           
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");
            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();

            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            builder.Property(u => u.ConcurrencyStamp).HasMaxLength(50);

            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            builder.Property(u => u.PhoneNumber).HasMaxLength(20);
            builder.Property(u => u.SecurityStamp).HasMaxLength(128);

            builder.Property(u => u.PasswordHash).HasMaxLength(256);

            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
        }
    }
    public class UserPhoneConfig : IEntityTypeConfiguration<UserPhone>
    {
        public void Configure(EntityTypeBuilder<UserPhone> builder)
        {
            builder.Property(x => x.Mobile).HasColumnType("nvarchar");
            builder.Property(x => x.TelephoneOne).HasColumnType("nvarchar");
            builder.Property(x => x.TelephoneTwo).HasColumnType("nvarchar");
            builder.Property(x => x.WhatsApp).HasColumnType("nvarchar");
        }
    }
}
