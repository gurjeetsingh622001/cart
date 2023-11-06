using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
