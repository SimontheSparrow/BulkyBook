using BulkyBook.Data.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.Data.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CoverTypeRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        

        public void Update(CoverType obj)
        {
           _context.CoverTypes.Update(obj);
        }
    }
}
