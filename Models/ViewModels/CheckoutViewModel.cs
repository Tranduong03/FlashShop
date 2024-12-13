using System.ComponentModel.DataAnnotations;

namespace FlashShop.Models
{
	public class CheckoutViewModel
	{
		[Display(Name = "Tên đăng nhập")]
		public string UserName { get; set; }

		[Display(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "Họ tên")]
		[Required(ErrorMessage = "Vui lòng nhập họ tên")]
		public string FullName { get; set; }

		[Display(Name = "Số điện thoại")]
		[Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
		[Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Địa chỉ")]
		[Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
		public string Address { get; set; }
	}
}
