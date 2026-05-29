using System.ComponentModel.DataAnnotations;

namespace BackendBookBroject.model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public string Isbn { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        public bool IsBorrowed { get; set; } = false;
    }
}
