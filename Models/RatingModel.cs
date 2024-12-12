using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models
{
    public class RatingModel
    {
        [Key]
        public int Id { get; set; }
        
        public int BookId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đánh giá sản phẩm!")]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên người dùng!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email!")]
        public string Email { get; set; }

        public string Rating { get; set; }

        [ForeignKey("BookId")]
        public BookModel Book { get; set; }
    }
}
