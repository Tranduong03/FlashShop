using System.ComponentModel.DataAnnotations;

namespace FlashShop.Models
{
    public class AccountCheck
    {
        public AccountCheck()
        {
        }

        public AccountCheck(string account, string password)
        {
            Account = account;
            Password = password;
        }

        [Required]
        public string Account { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
