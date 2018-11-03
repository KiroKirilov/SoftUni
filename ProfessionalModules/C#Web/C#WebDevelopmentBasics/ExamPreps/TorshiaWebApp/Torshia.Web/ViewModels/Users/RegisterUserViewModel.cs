using System;
using System.Collections.Generic;
using System.Text;

namespace Torshia.Web.ViewModels.Users
{
    public class RegisterUserViewModel:UserViewModel
    {
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
