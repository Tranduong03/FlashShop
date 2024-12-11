using System.ComponentModel.DataAnnotations;

namespace FlashShop.Models
{
    public class AccountCheck
    {
        [Required] 
        public string account { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        /*
         * Method for login (account and password)
         * */
        public AccountCheck() { }

        public AccountCheck(string account, string password)
        {
            this.account = account;
            this.password = password;
        }
    }
}
