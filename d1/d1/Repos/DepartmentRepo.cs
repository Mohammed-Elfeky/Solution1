using d1.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using d1.DTO;
namespace d1.Repos
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly context context;

        public DepartmentRepo(context context)
        {
            this.context = context;
        }
        public List<DeptWithEmpNames> GetAll()
        {
            List<DeptWithEmpNames> depts= context.
                   Departments.
                   Include(d => d.Employees).
                   Select(d => new DeptWithEmpNames {Id=d.Id, Name = d.Name, Manger = d.Manger, empNames = d.Employees.Select(e => e.Name).ToList() }).
                   ToList();
            return depts;
        }
        public DeptWithEmpNames FindById(int id)
        {
            return context.Departments.Include(d => d.Employees).
                   Select(d => new DeptWithEmpNames { Name = d.Name, Manger = d.Manger, empNames = d.Employees.Select(e => e.Name).ToList() }).
                   FirstOrDefault(x => x.Id == id);
        }
        public int addDepartment(Department d)
        {
                context.Add(d);
                context.SaveChanges();
                return d.Id;
        }
        public int addDepartmentImge(int id,string img)
        {
            Department olddept = context.Departments.Find(id);
            olddept.image = img;
            context.SaveChanges();
            return 1;
        }
    }
}
