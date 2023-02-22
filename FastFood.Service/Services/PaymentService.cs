using FastFood.Data.IRepositories;
using FastFood.Domain.Entities;
using FastFood.Service.Helpers;
using FastFood.Service.Interfaces;

namespace FastFood.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _paymentRepository= new IRepository<Payment>();
        private readonly IRepository<User> userRepository = new Repository<User>();
        public Task<Response<Payment>> AddAsync(Payment payment)
        {
            
        }

        public Task<Response<List<Payment>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<Payment>> GetByIdAsync(long? id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Payment>> UpdateAsync(long id, Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
