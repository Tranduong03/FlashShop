﻿using Microsoft.AspNetCore.Identity;

namespace FlashShop.Models
{
    public class AppUserModel : IdentityUser 
    {
       public string RoleId { get; set; }
    }
}
