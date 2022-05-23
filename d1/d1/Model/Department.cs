using System.Collections.Generic;

namespace d1.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manger { get; set; }
        public string image { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
