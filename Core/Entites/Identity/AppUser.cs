using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entites.Identity
{
    public class AppUser : IdentityUser
    {
        public string DesplayName { get; set; }
        
        public Address Address { get; set; }
    }
}
