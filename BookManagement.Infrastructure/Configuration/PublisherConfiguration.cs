using BookManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Infrastructure.Configuration;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable(nameof(Author));

        builder.HasKey(x => x.PublisherID);

        builder.Property(x => x.PublisherID)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.PublisherID)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Address)
            .IsRequired();
    }
}