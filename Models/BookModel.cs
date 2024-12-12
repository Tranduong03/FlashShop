using FlashShop.Repository.Validtation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Nhập Tên sách")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Nhập Giá bán")]
        [Column(TypeName = "decimal(15, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string ImgLink { get; set; }

        [NotMapped]
        [FileExtension]
        public IFormFile? ImgLinkUpload { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public int? Publication { get; set; } 

        public float? Point { get; set; }

        //Khóa ngoại tới bảng Category
        //[ValidateNever]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryModel Categories { get; set; }

        //public CategoryModel CategoryId { get; set; }

        //public PublisherModel PublisherId { get; set; }

        //[ValidateNever]
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public virtual PublisherModel Publisher { get; set; }

        public RatingModel Ratings { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Vui lòng nhập số lượng cần thêm.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng thêm phải lớn hơn 0.")]
        public int AddedQuantity { get; set; }

    }
}
