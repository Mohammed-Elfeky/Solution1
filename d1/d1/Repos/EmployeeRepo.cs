using d1.Model;
using System.Collections.Generic;
using System.Linq;
namespace d1.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly context context;

        public EmployeeRepo(context context)
        {
            this.context = context;
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public Employee FindById(int id)
        {
            return context.Employees.FirstOrDefault(x => x.Id == id);
        }
        public int Insert(Employee emp)
        {
            context.Employees.Add(emp);
            return context.SaveChanges();
        }
        public int Edit(int id, Employee emp)
        {
            Employee oldEmp = FindById(id);
            if (oldEmp != null)
            {
                oldEmp.Name = emp.Name;
                oldEmp.salary = emp.salary;
                oldEmp.Address = emp.Address;
                oldEmp.Phone = emp.Phone;
                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            Employee delEmp = FindById(id);
            context.Employees.Remove(delEmp);
            return context.SaveChanges();
        }

    }
}
