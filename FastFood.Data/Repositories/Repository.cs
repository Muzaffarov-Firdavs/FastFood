using FastFood.Data.Configurations;
using FastFood.Data.IRepositories;
using FastFood.Domain.Commons;
using FastFood.Domain.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FastFood.Data.Repositories
{
    public class Repository<TResult> : IRepository<TResult> where TResult : Auditable
    {
        private string path;
        public Repository()
        {
            if (typeof(TResult) == typeof(Product))
            {
                path = Constants.PRODUCT_PATH;
            }
            else if (typeof(TResult) == typeof(User))
            {
                path = Constants.USER_PATH;
            }
            else if (typeof(TResult) == typeof(Payment))
            {
                path = Constants.PAYMENT_PATH;
            }
            else if (typeof(TResult) == typeof(Order))
            {
                path = Constants.ORDER_PATH;
            }
            
        }
        public async Task<TResult>  CreateAsync(TResult value)
        {
            var model = await GetAllAsync();
            if(model.Count == 0)
            {
                value.Id = 1;
            }
            else
            {
                value.Id = model[model.Count - 1].Id+1;
            }
            value.CreatedAt = DateTime.UtcNow;
            model.Add(value);
            var jsonmodel = JsonConvert.SerializeObject(model);


        }

        public Task<bool> DeleteAsync(Predicate<TResult> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TResult>> GetAllAsync()
        {
            var models = await File.ReadAllTextAsync(path);
            if(models.Length == 0)
            {
                await File.WriteAllTextAsync(path, "[]");
                models = "[]";
            }

            var model = JsonConvert.DeserializeObject<List<TResult>>(models);
            return model;
        }

        public Task<TResult> GetAsync(Predicate<TResult> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> UpdateAsync(TResult value)
        {
            throw new NotImplementedException();
        }
    }
}
