using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.Core.Models;

namespace BookManagement.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookManagementContext _context;

        public BookRepository(BookManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.BookID == id);
        }

        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Update(Book model)
        {
            var existingBook = await _context.Books
                .Include(b => b.Publisher) 
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .FirstOrDefaultAsync(b => b.BookID == model.BookID);

            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = model.Title;
            existingBook.Genre = model.Genre;
            existingBook.PublishDate = model.PublishDate;
            existingBook.PublisherID = model.PublisherID;

            await _context.SaveChangesAsync();

            return existingBook;
        }


        public async Task Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Book>> GetBooksByAuthorWithPublisher(int authorId)
        {
            return await _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.Publisher)
                .Where(b => b.BookAuthors.Any(ba => ba.AuthorId == authorId))
                .ToListAsync();
        }
        
        public async Task<List<Book>> GetBooksByPublisher(int publisherId)
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Where(b => b.PublisherID == publisherId)
                .ToListAsync();
        }
    }
}