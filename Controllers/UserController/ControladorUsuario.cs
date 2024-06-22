using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarFood.Repository.IRepository;
using StarFood.Utility;

namespace StarFood.Controllers.UserController
{
    [Authorize(Roles = Roles.Admin_Role)]
    public class ControladorUsuario : Controller
    {
        private IUnitOfWork _db;
        private UserManager<IdentityUser> _userManager;

        public ControladorUsuario(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _db = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _db.Usuario.GetAll();
            if (User.IsInRole(Roles.Admin_Role))
            {
                IList<IdentityUser> usersAux = _userManager.GetUsersInRoleAsync(Roles.Admin_Role).Result;
                List<Models.Usuario> usersList = new List<Models.Usuario>();
                foreach (var user in usersAux)
                {
                    usersList.Add(_db.Usuario.GetFirstOrDefault(x => x.Id == user.Id, null));
                }
            }
            return View(users);
        }

        public IActionResult Edit(string? id)   //Update + Insert
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _db.Usuario.GetFirstOrDefault(x => x.Id == id, null);
            //var categoryFromDb = _db.Categories.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Usuario obj)
        {
            if (ModelState.IsValid)
            {
                _db.Usuario.Update(obj);
                _db.Save();
                TempData["success"] = "Usuario actualizado correctametne";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Attend(Models.Usuario obj)
        {
            if (ModelState.IsValid)
            {
                _db.Usuario.Update(obj);
                _db.Save();
                TempData["success"] = "Usuario actualizado correctamente";
            }
            return RedirectToAction("Index");
        }

        //POST
        [HttpPost]
        public IActionResult Banned(string? id)
        {
            if (id != null)
            {
                _userManager.SetLockoutEnabledAsync(_db.Usuario.GetFirstOrDefault(x => x.Id == id, null), true);
                _userManager.SetLockoutEndDateAsync(_db.Usuario.GetFirstOrDefault(x => x.Id == id, null), DateTimeOffset.MaxValue);
            }
            _db.Save();
            return Json(new { success = true, message = "Baneado correctamente" });
        }

        //POST
        [HttpPost]
        public IActionResult Unbanned(string? id)
        {
            if (id != null)
            {
                _userManager.SetLockoutEnabledAsync(_db.Usuario.GetFirstOrDefault(x => x.Id == id, null), false);
                _userManager.SetLockoutEndDateAsync(_db.Usuario.GetFirstOrDefault(x => x.Id == id, null), null);
            }
            _db.Save();
            return Json(new { success = true, message = "Desbaneado correctamente" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _db.Usuario.GetAll();
            return Json(new { data = users, success = true });
        }

        //[HttpGet]
        //public IActionResult GetAllMedical()
        //{
        //    IList<IdentityUser> users = _userManager.GetUsersInRoleAsync(Roles.Employee_Role).Result;
        //    List<Models.Usuario> usersList = new List<Models.Usuario>();
        //    foreach (var user in users)
        //    {
        //        usersList.Add(_db.Usuario.GetFirstOrDefault(x => x.Id == user.Id, null));
        //    }
        //    return Json(new { data = usersList, success = true });
        //}

    
    }
}
