using FastFood.Data.IRepositories;
using FastFood.Data.Repositories;
using FastFood.Domain.Entities;
using FastFood.Domain.Enums;
using FastFood.Service.Helpers;
using FastFood.Service.Interfaces;

namespace FastFood.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository = new Repository<Order> ();
        private readonly IRepository<Payment> paymentRepository = new Repository<Payment> ();
        public async Task<Response<Order>> AddAsync(Order order)
        {
            var payment = await paymentRepository.GetAsync(x => x.OrderId == order.PaymentId);
            foreach(var item in order.Items)
            {
                order.TotalAmount += item.Price;
            }
            
            if(payment is not null)
            {
                order.OrderStatus = OrderStatus.Pending;
                order.PaymentId = payment.Id;
            }
            await orderRepository.CreateAsync(order);
            return new Response<Order>
            {
                StatusCode = 200,
                Message = "Success",
                Result = order
            };
        }

        public async Task<Response<bool>> DeleteAsync(long id)
        {
            var order = await orderRepository.GetAsync(x => x.Id == id);
            if (order is null)
            {
                return new Response<bool>();
            }
            await orderRepository.DeleteAsync(x => x.Id==id);
            await paymentRepository.DeleteAsync(x => x.OrderId == id);
            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = true
            };
        }

        public async Task<Response<List<Order>>> GetAllAsync()
        {
            var result = await orderRepository.GetAllAsync();
            return new Response<List<Order>>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public async Task<Response<Order>> GetAsync(long id)
        {
           var result = await orderRepository.GetAsync(x=>x.Id == id);
            if(result is null )
            {
                return new Response<Order>();
            }
            return new Response<Order>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }

        public async Task<Response<Order>> UpdateAsync(long id, Order order)
        {
            var result = await orderRepository.GetAsync(x=> x.Id == id);
            if(result is null)
            {
                return new Response<Order>();
            }

            await orderRepository.UpdateAsync(order);
            return new Response<Order>()
            {
                StatusCode = 200,
                Message = "Success",
                Result = result
            };
        }
    }
}
