using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookManagement.Core.Models;

namespace BookManagement.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookManagementContext _context;

        public PublisherRepository(BookManagementContext context)
        {
            _context = context;
        }

        public async Task<Publisher> Create(Publisher model)
        {
            _context.Publishers.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Publisher> GetById(int id)
        {
            return await _context.Publishers
                .Include(p => p.Books) 
                .FirstOrDefaultAsync(p => p.PublisherID == id);
        }

        public async Task<List<Publisher>> GetAll()
        {
            return await _context.Publishers
                .Include(p => p.Books) 
                .ToListAsync();
        }

        public async Task<Publisher> Update(Publisher model)
        {
            var existingPublisher = await _context.Publishers.FindAsync(model.PublisherID);
            if (existingPublisher == null) return null;

            existingPublisher.Name = model.Name;
            existingPublisher.Address = model.Address;

            await _context.SaveChangesAsync();
            return existingPublisher;
        }

        public async Task Delete(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Publishers
                .AnyAsync(p => p.PublisherID == id, cancellationToken);
        }
    }
}