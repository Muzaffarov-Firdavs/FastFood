using FastFood.Domain.Entities;
using FastFood.Service.Helpers;

namespace FastFood.Service.Interfaces
{
    public interface IUserService
    {
        public Task<Response<User>> AddAsync(User user);
        public Task<Response<User>> UpdateAsync(long id,User user);
        public Task<Response<bool>> DeleteByIdAsync(long id);
        public Task<Response<List<User>>> GetAllAsync();
        public Task<Response<User>> GetByIdAsync(long id);
        public Task<Response<User>> GetByNameAsync(string name);
        public Task<Response<User>> GetAsync(Predicate<User> predicate = null);
    }
}
