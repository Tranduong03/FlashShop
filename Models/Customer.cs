using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashShop.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool TypeUser { get; set; } = true;

        [NotMapped] // Không lưu trường này vào cơ sở dữ liệu
        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

		public Customer() { }
		public Customer(int customerID, string customerName, string email, string account, string password, bool typeUser = true)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            Email = email;
            Account = account;
            Password = password;
            TypeUser = typeUser;
        }
    }
}
