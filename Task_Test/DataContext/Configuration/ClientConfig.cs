using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task_Test.DataContext.Configuration
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.Name).HasColumnType("nvarchar");
            builder.Property(x => x.District).HasColumnType("nvarchar");
            builder.Property(x => x.Address).HasColumnType("nvarchar");
            builder.Property(x => x.Job).HasColumnType("nvarchar");
            builder.Property(x => x.Natinality).HasColumnType("nvarchar");
            builder.Property(x => x.Residence).HasColumnType("nvarchar");
            builder.Property(x => x.AccountCreationDate).HasColumnType("nvarchar");
            builder.Property(x => x.DateModified).HasColumnType("nvarchar");

            //UserPhone Navigation
            builder.HasMany(x => x.Phones)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId).IsRequired();
        }
    }
}
