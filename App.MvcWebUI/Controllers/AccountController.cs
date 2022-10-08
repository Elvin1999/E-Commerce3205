using App.MvcWebUI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<CustomIdentityUser> _signInManager;

        public AccountController(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public AccountController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
