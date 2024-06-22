using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.User_Controller
{
    public class LoginController : Controller
    {
        private IUnitOfWork _db;
        private UserManager<IdentityUser> _userManager;

        public LoginController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _db = unitOfWork;
            _userManager = userManager;
        }

        //API 

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Login(string email, string contraseña)
        {
            IdentityUser user = _userManager.FindByEmailAsync(email).Result;
            if (user != null && _userManager.CheckPasswordAsync(user, contraseña).Result)
            {
                return Json(new { data = user.Id, success = true });
            }
            else
            {
                return Json(new { data = "No se pudo encontrar el usuario", success = false });
            }
        }
    }
}
