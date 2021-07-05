using Biblioteca.Core.DomainModels;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapping
{
    public class LoanMap : EntityTypeConfiguration<Loan>
    {
        public override void Configure(EntityTypeBuilder<Loan> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.BookId).HasColumnName("BookID");

            builder.Property(e => e.ClientId).HasColumnName("ClientID");

            builder.HasOne(d => d.Book)
                .WithMany(p => p.Loan)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Loan_Book");

            builder.HasOne(d => d.Client)
                .WithMany(p => p.Loan)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Loan_Client");

            builder.ToTable("Loan");
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(t => t.ClientId).HasColumnName("ClientId");
            builder.Property(t => t.BookId).HasColumnName("BookId");
            builder.Property(t => t.LoanDate).HasColumnName("LoanDate");
            builder.Property(t => t.ReturnDate).HasColumnName("ReturnDate");

            base.Configure(builder);
        }
    }
}
