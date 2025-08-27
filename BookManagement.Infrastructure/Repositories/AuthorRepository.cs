using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookManagementContext _context;

        public AuthorRepository(BookManagementContext context)
        {
            _context = context;
        }

        public async Task<Author> Create(Author model)
        {
            _context.Authors.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Author> GetById(int id)
        {
            return await _context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefaultAsync(a => a.AuthorID == id);
        }

        public async Task<List<Author>> GetAll()
        {
            return await _context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .ToListAsync();
        }

        public async Task<Author> Update(Author model)
        {
            var existingAuthor = await _context.Authors.FindAsync(model.AuthorID);
            if (existingAuthor == null) return null;
            
            existingAuthor.FirstName = model.FirstName;
            existingAuthor.LastName = model.LastName;
            existingAuthor.DateOfBirth = model.DateOfBirth;
            existingAuthor.Biography = model.Biography;

            await _context.SaveChangesAsync();
            return existingAuthor;
        }

        public async Task Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Author>> GetAllAuthorsByBook(int bookId)
        {
            return await _context.BookAuthors
                .Where(ba => ba.BookId == bookId)
                .Select(ba => ba.Author)
                .ToListAsync();
        }
    }
}
