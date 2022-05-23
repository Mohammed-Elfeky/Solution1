using d1.Model;
using System.Collections.Generic;

namespace d1.Repos
{
    public interface IEmployeeRepo
    {
        int Delete(int id);
        int Edit(int id, Employee emp);
        Employee FindById(int id);
        List<Employee> GetAll();
        int Insert(Employee emp);
    }
}