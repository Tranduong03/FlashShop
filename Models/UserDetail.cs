namespace FlashShop.Models
{
	public class UserDetail
	{
		public int Id { get; set; }
		public string UserId { get; set; } // Khóa ngoại đến AspNetUsers
		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }

		// Liên kết với bảng người dùng
		public virtual AppUserModel User { get; set; }
	}
}
