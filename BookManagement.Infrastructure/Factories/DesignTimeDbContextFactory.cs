using BookManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using BookManagement.Infrastructure.Entities;

namespace BookManagement.Infrastructure.Factories;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BookManagementContext>
{
    public BookManagementContext CreateDbContext(string[] args = null)
    {
        // MySQL connection string
        var connectionString = "Server=localhost;Database=BookManagementDb;User Id=root;Password=Sasho07!;";

        var optionsBuilder = new DbContextOptionsBuilder<BookManagementContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new BookManagementContext(optionsBuilder.Options);
    }
}