using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace d1.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal salary { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

        [ForeignKey("Department")]
        public int dept_id { get; set; }
        public virtual Department Department { get; set; }
    }
}
