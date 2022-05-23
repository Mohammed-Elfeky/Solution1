using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string info { get; set; }
        [Required]
        [Range(300, 3000)]
        public int price { get; set; }
        public string image { get; set; }

        [ForeignKey("Category")]
        public int cat_Id { get; set; }
        public virtual Category Category { get; set; }
    }
}
