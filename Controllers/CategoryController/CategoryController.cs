using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.CategoryController
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        
        public CategoryController (IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            IEnumerable<Categoria> categoryList = _unitOfWork.Categoria.GetAll();
            return View(categoryList);
        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Add(category);
                _unitOfWork.Save();
            }
            TempData["success"] = "Categoria agregada correctamente";
            return RedirectToAction("Index");
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
