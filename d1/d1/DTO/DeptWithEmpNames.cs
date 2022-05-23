using d1.Model;
using System.Collections.Generic;

namespace d1.DTO
{
    public class DeptWithEmpNames
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manger { get; set;  }

        public List<string> empNames { get; set; } = new List<string>();
    }
}
