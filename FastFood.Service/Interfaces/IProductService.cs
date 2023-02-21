using FastFood.Domain.Entities;
using FastFood.Service.Helpers;

namespace FastFood.Service.Interfaces
{
    public interface IProductService
    {
        public Task<Response<Product>> AddAsync(Product product);
        public Task<Response<Product>> UpdateAsync(long id,Product product);
        public Task<Response<bool>> DeleteByIdAsync(long id,long ownid);
        public Task<Response<List<Product>>> GetAllAsync();
        public Task<Response<Product>> GetByIdAsync(long id);
        public Task<Response<Product>> GetByNameAsync(string name);
        public Task<Response<Product>> GetAsync(Predicate<Product> predicate = null);
    }
}
