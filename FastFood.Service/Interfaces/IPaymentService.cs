using FastFood.Domain.Entities;
using FastFood.Service.Helpers;

namespace FastFood.Service.Interfaces
{
    public interface IPaymentService
    {
        public Task<Response<Payment>> AddAsync(Payment payment);
        public Task<Response<Payment>> UpdateAsync(long id, Payment payment);
        public Task<Response<Payment>> GetByIdAsync(long? id);
        public Task<Response<List<Payment>>> GetAllAsync();
    }
}
