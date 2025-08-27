using BookManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Infrastructure.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(nameof(Book));
        
        builder.HasKey(x => x.BookID);
        
        builder.Property(x => x.BookID)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Genre)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.PublishDate)
            .IsRequired();

        builder.Property(x => x.PublisherID)
            .IsRequired();

    }
}