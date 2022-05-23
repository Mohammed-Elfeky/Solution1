using d1.Model;
using System.Collections.Generic;
using d1.DTO;
namespace d1.Repos
{
    public interface IDepartmentRepo
    {
        DeptWithEmpNames FindById(int id);
        List<DeptWithEmpNames> GetAll();
        int addDepartment(Department d);
        int addDepartmentImge(int id, string img);
    }
}