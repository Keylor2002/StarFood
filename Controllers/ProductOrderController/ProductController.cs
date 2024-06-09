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
        public IActionResult Create([FromBody] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Add(producto);
                _unitOfWork.Save();
                return Json(new { success = true, message = "producto creada correctamente" });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
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

            return Json(new { success = true, data = producto });
        }

  

        // Works
        [HttpPost]
        public IActionResult Update([FromBody] Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.IDProducto == 0 || producto.IDProducto == null)
                    _unitOfWork.Producto.Add(producto);
                else
                    _unitOfWork.Producto.Update(producto);

                _unitOfWork.Save();
                TempData["success"] = "product saved successfully";
            }
            else
            {
                TempData["error"] = "Error saving product";
            }

            return Json(new { success = true, data = producto });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var ProductToDelete = _unitOfWork.Producto.Get(u => u.IDProducto == id);

            if (ProductToDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting product" });
            }

            _unitOfWork.Producto.Remove(ProductToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Product deleted successfully" });
        }


        // Works
        public IActionResult GetAll()
        {
            var category = _unitOfWork.Producto.GetAll();
            return Json(new { data = category, success = true });
        }
    }
}
