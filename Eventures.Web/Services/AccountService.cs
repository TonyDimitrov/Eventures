
using Data.Web;
using Eventures.Web.Services.Interfaces;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Models.Web;
using System.Linq;
using System.Security.Claims;

namespace Eventures.Web.Services
{
    public class AccountService : IAccountService
    {
        public bool Register(SignInManager<EventureUser> signIn, RegisterVM model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }
            var user = new EventureUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Ucn = model.Ucn
            };
            var result = signIn.UserManager.CreateAsync(user, model.Password)
                .GetAwaiter()
                .GetResult()
                .Succeeded;
            if (result && signIn.UserManager.Users.Count() == 1)
            {
                this.SetRole(signIn, model, "Admin");
            }
            return result;
        }

        public bool Login(SignInManager<EventureUser> signIn, LoginVM model)
        {
            var user = signIn.UserManager.FindByNameAsync(model.Username)
                .GetAwaiter()
                .GetResult();
            if (user == null)
            {
                return false;
            }
            var result = signIn.PasswordSignInAsync(user, model.Password, model.RememberMe, false)
                .GetAwaiter()
                .GetResult()
                .Succeeded;
            return result;
        }

        public bool Loout(SignInManager<EventureUser> signIn, ClaimsPrincipal model)
        {
            signIn.SignOutAsync()
                .GetAwaiter()
                .GetResult();
          //  var user = signIn.UserManager.FindByNameAsync(model.Username);
         //   signIn.IsSignedIn(this.User);
            return true;
        }

        bool SetRole(SignInManager<EventureUser> signIn, LoginVM model, string role)
        {
            var user = signIn.UserManager.FindByNameAsync(model.Username)
                .GetAwaiter()
                .GetResult();
           var added = signIn.UserManager.AddToRoleAsync(user, role)
                .GetAwaiter()
                .GetResult()
                .Succeeded;
            return added;
        }
    }
}
