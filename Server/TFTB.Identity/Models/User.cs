using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFTB.Identity.Models
{
    public class User : IdentityUser
    {
        public int Money { get; set; } = 0;
        public string Fullname { get; set; }
        public ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();
    }
}
