﻿using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string OverView { get; set; }
        public string AboutMe { get; set; }
        public string Experiences { get; set; }
        public string Education { get; set; }

    }
}
