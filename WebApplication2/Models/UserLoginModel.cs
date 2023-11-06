using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class UserLoginModel
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }

}