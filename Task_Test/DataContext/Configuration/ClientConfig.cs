using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task_Test.DataContext.Configuration
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.Property(x => x.District).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Address).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Job).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Natinality).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Residence).HasColumnType("nvarchar(200)");

            //UserPhone Navigation
            builder.HasMany(x => x.Phones)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId).IsRequired();
        }
    }
}
