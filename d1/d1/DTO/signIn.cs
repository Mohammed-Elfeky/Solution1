using System.ComponentModel.DataAnnotations;
namespace d1.DTO
{
    public class signIn
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
