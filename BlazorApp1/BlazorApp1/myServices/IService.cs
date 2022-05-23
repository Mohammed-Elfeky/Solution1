using System.Collections.Generic;
using System.Threading.Tasks;
using models;
namespace BlazorApp1.myServices
{
    public interface IService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetByID(int id);
        Task Insert(Product item);
        Task Update(int id, Product item);
        Task Delete(int id);
    }
}
