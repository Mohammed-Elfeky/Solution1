using models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.myServices
{
    public class ProductService : IService
    {
        private readonly HttpClient httpclient;

        public ProductService(HttpClient httpclient)
        {
            this.httpclient = httpclient;
        }
        public async Task Delete(int id)
        {
            await httpclient.DeleteAsync("/api/Products/" + id);
        }

        public async Task<List<Product>> GetAll()
        {
            var res= await httpclient.GetFromJsonAsync<List<Product>>("/api/Products/");
            return res;
        }

        public async Task<Product> GetByID(int id)
        {
            return await httpclient.GetFromJsonAsync<Product>("/api/Products/" + id);
        }

        public async Task Insert(Product item)
        {
            await httpclient.PostAsJsonAsync<Product>("/api/Products", item);
        }

        public async Task Update(int id, Product item)
        {
            await httpclient.PutAsJsonAsync<Product>("/api/Products/" + id, item);
        }
    }
}
