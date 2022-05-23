using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using models;
namespace BlazorApp1.myServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpclient;

        public CategoryService(HttpClient httpclient)
        {
            this.httpclient = httpclient;
        }
        public async Task Delete(int id)
        {
            await httpclient.DeleteAsync("/api/Categories/" + id);
        }

        public async Task<List<Category>> GetAll()
        {
            var res = await httpclient.GetFromJsonAsync<List<Category>>("/api/Categories/");
            return res;
        }

        public async Task<Category> GetByID(int id)
        {
            return await httpclient.GetFromJsonAsync<Category>("/api/Categories/" + id);
        }

        public async Task Insert(Category item)
        {
            await httpclient.PostAsJsonAsync<Category>("/api/Categories", item);
        }

        public async Task Update(int id, Category item)
        {
            await httpclient.PutAsJsonAsync<Category>("/api/Categories/" + id, item);
        }
    }
}
