using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task_Test.DataContext.Configuration
{
    public class UserPhoneConfig : IEntityTypeConfiguration<UserPhone>
    {
        public void Configure(EntityTypeBuilder<UserPhone> builder)
        {
            builder.Property(x => x.Mobile).HasColumnType("nvarchar(200)");
            builder.Property(x => x.TelephoneOne).HasColumnType("nvarchar(200)");
            builder.Property(x => x.TelephoneTwo).HasColumnType("nvarchar(200)");
            builder.Property(x => x.WhatsApp).HasColumnType("nvarchar(200)");
        }
    }
}
