﻿using Microsoft.AspNetCore.Identity;

namespace InternshipApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string confirmPassword { get; set; }
    }
}