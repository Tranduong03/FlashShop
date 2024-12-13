namespace FlashShop.Models.ViewModels
{
	public class EditProfileViewModel
	{
		public string UserName { get; set; } // Readonly
		public string Email { get; set; } // Readonly
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
	}

}
