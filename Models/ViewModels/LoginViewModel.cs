using System.ComponentModel.DataAnnotations;

namespace FlashShop.Models.ViewModels
{
    public class LoginViewModel
    {
        public int userID { get; set; }

        //[Required(ErrorMessage = "Vui lòng nhập Tài khoản")]
        //public string account { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(20)]  [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Tên đăng nhập")]
        public string userName { get; set; }

        public String ReturnUrl { get; set; }
    }
}
