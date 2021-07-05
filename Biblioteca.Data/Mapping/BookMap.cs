using Biblioteca.Core.DomainModels;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)

        {
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Publisher)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Year)
                .IsRequired()
                .HasMaxLength(50);

            builder.ToTable("Book");
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(t => t.Title).HasColumnName("Title");
            builder.Property(t => t.Author).HasColumnName("Author");
            builder.Property(t => t.Publisher).HasColumnName("Publisher");
            builder.Property(t => t.Year).HasColumnName("Year");

            base.Configure(builder);
        }

    }
}
