using Data.Web;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eventures.Web.Services.Interfaces
{
   public interface IAccountService
    {
        bool Register(SignInManager<EventureUser> signIn, RegisterVM model);

        bool Login(SignInManager<EventureUser> signIn, LoginVM model);

        bool Loout(SignInManager<EventureUser> signIn, ClaimsPrincipal model);


    }
}
