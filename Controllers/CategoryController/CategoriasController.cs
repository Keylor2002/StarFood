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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound(new { success = false, message = "ID no proporcionado" });
            }

            var categoria = _unitOfWork.Categoria.GetFirstOrDefault(x => x.IDCategoria == id, null);
            if (categoria == null)
            {
                return NotFound(new { success = false, message = "Categoría no encontrada" });
            }

            return Json(new { success = true, data = categoria });
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromBody] Categoria categoria)
        {
            if (categoria == null || categoria.IDCategoria == 0)
            {
                return BadRequest(new { success = false, message = "Datos de categoría no proporcionados o inválidos" });
            }

            var categoriaEnDb = _unitOfWork.Categoria.GetFirstOrDefault(x => x.IDCategoria == categoria.IDCategoria, null);
            if (categoriaEnDb == null)
            {
                return NotFound(new { success = false, message = "Categoría no encontrada" });
            }

            categoriaEnDb.Nombre = categoria.Nombre;

            _unitOfWork.Categoria.Update(categoriaEnDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Categoría actualizada correctamente" });
        }

        public IActionResult GetAll()
        {
            var category = _unitOfWork.Categoria.GetAll();
            return Json(new { data = category, success = true });
        }
    }
}
