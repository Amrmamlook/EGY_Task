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
                .HasForeignKey(x => x.ClientId).IsRequired().OnDelete(DeleteBehavior.ClientCascade);

            //Calls Navigation
            builder.HasMany(x=>x.Calls)
                .WithOne(x=>x.Client)
                .HasForeignKey(x=>x.ClientId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
    public class CallsConfig : IEntityTypeConfiguration<Calls>
    {
        public void Configure(EntityTypeBuilder<Calls> builder)
        {
            builder.Property(x => x.Description).HasColumnType("nvarchar(250)");
            builder.Property(x => x.Employee).HasColumnName("nvarchar(100)");
            builder.Property(x => x.project).HasColumnName("nvarchar(200)");
            builder.Property(x => x.TypeOfCall).HasColumnName("nvarchar(50)");
            builder.Property(x => x.CallAdress).HasColumnName("nvarchar(150)");
        }
    }
}
