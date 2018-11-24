using Data.Web;
using Eventures.Web.Services.Interfaces;
using Eventures.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Web;

namespace Eventures.Web.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<EventureUser> signIn;
        private EventuresDbContext dbContext;
        private IAccountService accountService;

        public AccountController(SignInManager<EventureUser> signIn, EventuresDbContext dbContext, IAccountService accountService)
        {
            this.signIn = signIn;
            this.dbContext = dbContext;
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var isRegistered = this.accountService.Register(signIn, model);
                if (isRegistered)
                {
                    return this.Redirect("/home/index");
                }
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var loggedIn = this.accountService.Login(signIn, model);
                if (loggedIn)
                {
                    return this.Redirect("/home/index");
                }
            }
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.accountService.Loout(signIn, this.User);
            return this.Redirect("/home/index");
        }
    }
}
