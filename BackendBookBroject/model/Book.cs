using System.ComponentModel.DataAnnotations;

namespace BackendBookBroject.model
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public int quantity { get; set; }

        public bool isBarrowed { get; set; } = false;
    }
}
