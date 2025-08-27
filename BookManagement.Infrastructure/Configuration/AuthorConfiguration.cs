using BookManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Infrastructure.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(nameof(Author));
        
        builder.HasKey(x => x.AuthorID);
        
        builder.Property(x => x.AuthorID)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.DateOfBirth)
            .IsRequired();
        
        builder.Property(x => x.Biography)
            .IsRequired();
        
        
        
        
    }
}