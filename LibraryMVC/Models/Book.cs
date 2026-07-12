using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMVC.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Title { get; set; }
        [Required,MaxLength(100)]
        public string Author { get; set; }
        // foreign key for category
        [ForeignKey("Category")]
        public int CatId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; } = 0;
        [Required]
        public int Quentity { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;

    }
}
