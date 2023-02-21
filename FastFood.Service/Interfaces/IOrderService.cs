using FastFood.Domain.Entities;
using FastFood.Service.Helpers;

namespace FastFood.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<Response<Order>> AddAsync(Order order);
        public Task<Response<bool>> DeleteAsync(long id);
        public Task<Response<Order>> GetAsync(long id);
        public Task<Response<List<Order>>> GetAllAsync();
        public Task<Response<Order>> UpdateAsync(long id, Order order);
    }
}
