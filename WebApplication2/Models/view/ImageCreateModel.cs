namespace WebApplication2.Models.view
{
    public class ImageCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
