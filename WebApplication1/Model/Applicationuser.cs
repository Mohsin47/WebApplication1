using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class Applicationuser:IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
