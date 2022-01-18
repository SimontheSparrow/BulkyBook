using BulkyBook.Models;

namespace BulkyBook.Data.Repository.IRepository
{
    public interface ICoverTypeRepository: IRepository<CoverType>
    {
        void Update(CoverType obj);
        
    }
}
