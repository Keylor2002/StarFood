using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.ProductController
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<Producto> ProductList = _unitOfWork.Producto.GetAll();
            return View(ProductList);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        public IActionResult Create([FromBody] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Add(producto);
                _unitOfWork.Save();
                return Json(new { success = true, message = "producto creada correctamente" });
            }

            return RedirectToAction("Index");
        }


        // Works
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound(new { success = false, message = "ID no proporcionado" });
            }

            var producto = _unitOfWork.Producto.GetFirstOrDefault(x => x.IDProducto == id, null);
            if (producto == null)
            {
                return NotFound(new { success = false, message = "Producto no encontrado" });
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Update(producto);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Categoria editada correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    var CategoryToDelete = _unitOfWork.Categoria.Get(u => u.IDCategoria == id);

        //    if (CategoryToDelete == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting category" });
        //    }

        //    _unitOfWork.Categoria.Remove(CategoryToDelete);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Category deleted successfully" });
        //}

        //public IActionResult Suspend(int? id)
        //{

        //    var category = _unitOfWork.Categoria.GetFirstOrDefault(x => x.IDCategoria == id, null);

        //    if (category.Suspendido == false)
        //    {
        //        category.Suspendido = true;
        //        TempData["success"] = "Categoria suspendida correctamente";
        //    }
        //    else
        //    {
        //        category.Suspendida = false;
        //        TempData["success"] = "La categoria se activo correctamente";
        //    }
        //    _unitOfWork.Categoria.Update(category);
        //    _unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}

        // Works
        public IActionResult GetAll()
        {
            var category = _unitOfWork.Producto.GetAll();
            return Json(new { data = category, success = true });
        }
    }
}
