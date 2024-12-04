using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Tên đăng nhập")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Tài khoản")]
        public string account { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool typeUser { get; set; } = true;

        [NotMapped] // Không lưu trường này vào cơ sở dữ liệu
        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

		public Users() { }
        public Users(int userID, string userName, string email, string account, string password, bool typeUser = true)
        {
            this.userID = userID;
            this.userName = userName;
            this.email = email;
            this.account = account;
            this.password = password;
            this.typeUser = typeUser;
        }
    }
}
