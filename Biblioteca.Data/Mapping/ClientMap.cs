using Biblioteca.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Data.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.ToTable("Client");
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(t => t.LastName).HasColumnName("LastName");
            builder.Property(t => t.FirstName).HasColumnName("FirstName");
            builder.Property(t => t.Phone).HasColumnName("Phone");
            builder.Property(t => t.Adress).HasColumnName("Adress");

            base.Configure(builder);
        }
    }
}
