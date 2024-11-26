using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "decimal(15, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ImgLink { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public int? Publication { get; set; } // Nullable để xử lý khi năm xuất bản có thể không được cung cấp

        public float? Point { get; set; } // Nullable để xử lý khi điểm đánh giá có thể không được cung cấp

        // Khóa ngoại tới bảng Category
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryModel Categories { get; set; }

        public int? PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public virtual PublisherModel Publisher { get; set; }
        
        [NotMapped]
        [FileExtensions]
        public IFormFile ImgLinkUpload { get; set; }
    }
}
