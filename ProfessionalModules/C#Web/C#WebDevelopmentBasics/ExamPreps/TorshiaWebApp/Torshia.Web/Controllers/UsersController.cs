using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using SIS.Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torshia.Models;
using Torshia.Models.Enums;
using Torshia.Web.ViewModels.Users;

namespace Torshia.Web.Controllers
{
    public class UsersController : BaseController
    {
        public IActionResult Register()
        {
            return this.RenderView();
        }

        public IActionResult Login()
        {
            return this.RenderView();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            var userExists = this.Db.Users.Any(u => u.Username == model.Username.Trim());

            if (userExists)
            {
                return this.RedirectToAction("/");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.RedirectToAction("/Users/Register");
            }

            var role = this.Db.Users.Any() ? Role.User : Role.Admin;

            var user = new User
            {
                Username = model.Username.Trim(),
                Password = model.Password,
                Email = model.Email,
                Role = role
            };

            this.Db.Users.Add(user);
            this.Db.SaveChanges();

            return this.RedirectToAction("/Users/Login");
        }

        [HttpPost]
        public IActionResult Login(UserViewModel model)
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user==null)
            {
                return this.RedirectToAction("/Users/Login");
            }

            this.SignIn(new IdentityUser
            {
                Id = user.Id.ToString(),
                Username = user.Username,
                Roles = new List<string> { user.Role.ToString() }
            });

            return this.RedirectToAction("/");
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToAction("/");
        }
    }
}
