﻿using Microsoft.AspNetCore.Identity;

namespace FlashShop.Models
{
    public class AppUserModel : IdentityUser 
    {
        public string RoleId { get; set; }

        public string Token { get; set; }

        public string FullName { get; set; }

        public string Address  { get; set; }
    }
}
