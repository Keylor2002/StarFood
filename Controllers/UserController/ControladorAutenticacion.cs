using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarFood.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace StarFood.Controllers.UserController
{
    [ApiController]
    [EnableCors("GeneralPolicy")]
    public class ControladorAutenticacion : Controller
    {
        private readonly IUnitOfWork _db;
        private UserManager<IdentityUser> _userManager;

        public ControladorAutenticacion(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _db = unitOfWork;
            _userManager = userManager;
        }

        //API
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            IdentityUser user = _userManager.FindByEmailAsync(email).Result;
            bool isCorrect = _userManager.CheckPasswordAsync(user, password).Result;
            if (user != null && isCorrect)
            {
                return Json(new { data = user, success = true });
            }
            else
            {
                string errorData = "";
                if (user == null)
                {
                    errorData = "Usuario no encontrado";
                }
                else if (isCorrect == false)
                {
                    errorData = "Contraseña incorrecta";
                }
                return Json(new { data = errorData, success = false });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("userInfo")]
        public IActionResult UserInfo(string idUsuario)
        {
            IdentityUser u = _userManager.FindByIdAsync(idUsuario).Result;
            Models.Usuario user = (Models.Usuario)u;
            if (user != null)
            {
                return Json(new { data = user, sucess = true });
            }
            else
            {
                return Json(new { data = "No se pudo encontrar el usuario", sucess = true });

            }
        }

    }

}
