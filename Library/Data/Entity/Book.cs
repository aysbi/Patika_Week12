using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entity
{
    [Table("Books")]
    [Index(nameof(Author), IsUnique = true)]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string Author { get; set; }

        public int PublicationYear { get; set; }

        [Column("BookPrice", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        [Column("LastBorrowed")]
        public DateTime? LastBorrowedDate { get; set; }

        public List<Review> Reviews { get; set; }

        public BookDetail Detail { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Author> Authors { get; set; }
    }
}
