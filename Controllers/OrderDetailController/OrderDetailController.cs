using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.OrderDetailController
{
    public class OrderDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public OrderDetailController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
           // IEnumerable<DetallePedido> OrderDetailList = _unitOfWork.DetallePedido.GetAll();
            //return View(DishList);

        }


        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        public IActionResult Create([FromBody] Platillo platillo)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Platillo.Add(platillo);
                _unitOfWork.Save();
                return Json(new { success = true, message = "platillo creado correctamente" });
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

            var platillo = _unitOfWork.Platillo.GetFirstOrDefault(x => x.IDPlatillo == id, null);
            if (platillo == null)
            {
                return NotFound(new { success = false, message = "Platillo no encontrado" });
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] Platillo platillo)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Platillo.Update(platillo);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Platillo editada correctamente";
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