using ChushkaWebApp.Models;
using ChushkaWebApp.ViewModels.Users;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChushkaWebApp.Controllers
{
    public class UsersController: BaseController
    {
        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(RegisterViewModel model)
        {
            if (model == null)
            {
                return this.BadRequestErrorWithView("Please fill out the form.");
            }

            var userExists = this.Db.Users.Any(u => u.Username == model.Username);

            if (userExists)
            {
                return this.BadRequestErrorWithView("User with the same username already exists.");
            }

            if (model.Password!=model.ConfirmPassword)
            {
                return this.BadRequestErrorWithView("The provided passwords do not match.");
            }

            var role = this.Db.Users.Any() ? Role.User : Role.Admin;

            var user = new User()
            {
                Username = model.Username,
                FullName = model.FullName,
                Password = model.Password,
                Email = model.Email,
                Role = role
            };

            this.Db.Users.Add(user);
            this.Db.SaveChanges();

            return this.Redirect("/Users/Login");
        }

        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(LoginViewModel model)
        {
            if (model==null)
            {
                return this.BadRequestErrorWithView("Please fill out the form.");
            }

            var user = this.Db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password==model.Password);

            if (user==null)
            {
                return this.BadRequestErrorWithView("Username and password do not match.");
            }

            var mvcUser = new MvcUserInfo()
            {
                Username = user.Username,
                Role = user.Role.ToString()
            };

            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);
            var cookie = new HttpCookie(".auth-cakes", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);

            return this.Redirect("/");
        }

        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }
    }
}
