using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ImagePath { get; set; }
    }
}
