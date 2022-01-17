using BulkyBook.Models;

namespace BulkyBook.Data.Repository.IRepository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        void Update(Category obj);
      
    }
}
