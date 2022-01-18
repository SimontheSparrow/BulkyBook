using BulkyBook.Models;

namespace BulkyBook.Data.Repository.IRepository
{
    public interface IProductRepository: IRepository<Product>
    {
        void Update(Product obj);
        
    }
}
