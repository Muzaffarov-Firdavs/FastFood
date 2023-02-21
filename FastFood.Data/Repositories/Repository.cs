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
        private List<TResult> entities = new List<TResult>();
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
            File.WriteAllText(path, jsonmodel);
            return value;
        }

        public async Task<bool> DeleteAsync(Predicate<TResult> predicate)
        {
            TResult model = await GetAsync(x=> predicate(x));
            if (model is null) return false;
            entities.Remove(model);

            string jsonmodel = JsonConvert.SerializeObject(model);
            File.WriteAllText(path, jsonmodel);
            return true;    
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

        public async Task<TResult> GetAsync(Predicate<TResult> predicate)
        {
            var models = await GetAllAsync();
            return models.FirstOrDefault(x => predicate(x));
        }

        public async Task<TResult> UpdateAsync(TResult value)
        {
            TResult result= await GetAsync(x=>x.Id==value.Id);
            result.UpdatedAt = DateTime.UtcNow;
            int index = entities.IndexOf(result);
            entities.RemoveAt(index);
            entities.Insert(index, value);

            File.WriteAllText(path, JsonConvert.SerializeObject(entities));
            return value;

        }
    }
}
