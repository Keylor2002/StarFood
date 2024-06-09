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


        public IActionResult Index()
        {
            //IEnumerable<Categoria> categoryList = _unitOfWork.Categoria.GetAll();
            //return View(categoryList);
            return View();
        }

        
        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        public IActionResult Create([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Add(categoria);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria creada correctamente" });
            }
            TempData["success"] = "Categoria creada correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        // Works
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

        [HttpPost]
        public IActionResult EjecutarUpdate()
        {
            Categoria categoria = new Categoria
            {
                IDCategoria = 1,
                Nombre = "Nueva categoría actualizada" 
            };

            var result = Update(categoria);


            return Ok(result);
        }

        // Works
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] Categoria category)
        {
            if (ModelState.IsValid)
            {
                if (_category.IDCategoria == 0 || _category.IDCategoria == null)
                    _unitOfWork.Categoria.Add(_category);
                else
                    _unitOfWork.Categoria.Update(_category);

                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Categoria editada correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        // Works
        public IActionResult GetAll()
        {
            var category = _unitOfWork.Categoria.GetAll();
            return Json(new { data = category, success = true });
        }
    }
}
