using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.CategoryController
{
    public class CategoriasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        
        public CategoriasController (IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            //IEnumerable<Categoria> categoryList = _unitOfWork.Categoria.GetAll();
            //return View(categoryList);
            return View();
        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Add(categoria);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Categoria creada correctamente" });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        // GET: CategoryController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _unitOfWork.Categoria.GetFirstOrDefault(x => x.IDCategoria == id, null);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Update(category);
                _unitOfWork.Save();
            }
            TempData["success"] = "Categoria editada correctamente";
            return RedirectToAction("Index");

        }

        public IActionResult GetAll()
        {
            var category = _unitOfWork.Categoria.GetAll();
            return Json(new { data = category, success = true });
        }
    }
}
