using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.User_Controller
{
    public class ControladorLogin : Controller
    {
        private IUnitOfWork _db;
        private UserManager<IdentityUser> _userManager;

        public ControladorLogin(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _db = unitOfWork;
            _userManager = userManager;
        }

        //API 

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Login(string nombreUsuario, string contraseña)
        {
            IdentityUser user = _userManager.FindByNameAsync(nombreUsuario).Result;
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
