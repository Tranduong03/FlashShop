using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookModel BookDetails { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đánh giá về sản phẩm")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên người dùng")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
    }
}
