using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFTB.Identity.Models;

namespace TFTB.Identity.ViewModels
{
    public class RegisterResponseViewModel
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Money { get; set; }

        public RegisterResponseViewModel(User user)
        {
            Id = user.Id;
            Fullname = user.Fullname;
            Email = user.Email;
            Money = user.Money.ToString();
        }
    }
}
