using models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.myServices
{
    public interface ICategoryService
    {
        Task Delete(int id);
        Task<List<Category>> GetAll();
        Task<Category> GetByID(int id);
        Task Insert(Category item);
        Task Update(int id, Category item);
    }
}