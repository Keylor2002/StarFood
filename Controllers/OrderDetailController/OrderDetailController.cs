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
            IEnumerable<DetalleOrden> orderDetailList = _unitOfWork.DetalleOrden.GetAll();
            return View(orderDetailList);

        }


        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(DetalleOrden orderDetail)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DetalleOrden.Add(orderDetail);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Detalle de orden creada correctamente" });
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

            var orderDetail = _unitOfWork.DetalleOrden.GetFirstOrDefault(x => x.IDDetalleOrden == id, null);
            if (orderDetail == null)
            {
                return NotFound(new { success = false, message = "Detalle de pedido no encontrado" });
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] DetalleOrden orderDetail)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DetalleOrden.Update(orderDetail);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Detalle de orden editada correctamente";
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
            var orderDetail = _unitOfWork.DetalleOrden.GetAll();
            return Json(new { data = orderDetail, success = true });
        }
    }
}