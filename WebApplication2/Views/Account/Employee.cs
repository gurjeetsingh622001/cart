using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender cannot be blank")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email cannot be blank")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Country cannot be blank")]
        public string Country { get; set; }

    }
}
