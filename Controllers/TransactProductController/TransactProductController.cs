using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.TransactProductController
{
    public class TransactProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public TransactProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<TransaccionProducto> TransaccionList = _unitOfWork.TransaccionProducto.GetAll();
            return View(TransaccionList);

        }


        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TransaccionProducto transaccionProducto)
        {
            if (ModelState.IsValid)
            {
                var producto = _unitOfWork.Producto.GetFirstOrDefault(x => x.IDProducto == transaccionProducto.IDProducto, null);
                producto.PrecioVenta = transaccionProducto.PrecioVenta;
                _unitOfWork.Producto.Update(producto);
                _unitOfWork.TransaccionProducto.Add(transaccionProducto);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria creada correctamente" });
                return RedirectToAction("Index");
            }
            TempData["success"] = "Lote de producto creado correctamente";
            return View(transaccionProducto);
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        // Works
        //[HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var transaccionProducto = _unitOfWork.TransaccionProducto.GetFirstOrDefault(x => x.IDProducto == id, null);
            if (transaccionProducto == null)
            {
                return NotFound();
            }

            return View(transaccionProducto);
        }


        // Works

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TransaccionProducto transaccionProducto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TransaccionProducto.Update(transaccionProducto);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Lote de producto editado correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        public IActionResult ToggleSuspend(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccionProducto = _unitOfWork.TransaccionProducto.GetFirstOrDefault(x => x.IDProducto == id, null);
            if (transaccionProducto == null)
            {
                return NotFound();
            }

            
            _unitOfWork.TransaccionProducto.Update(transaccionProducto);
            _unitOfWork.Save();

            

            return RedirectToAction("Index");
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
            var transaccionProducto = _unitOfWork.TransaccionProducto.GetAll();
            return Json(new { data = transaccionProducto, success = true });
        }
    }
}
