using System;
using System.Threading.Tasks;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Persistence.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _context;
        
        public UnitofWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}