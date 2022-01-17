using BulkyBook.Data.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            CoverType = new CoverTypeRepository(_context);
        }

        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
