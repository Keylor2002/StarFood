using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.ProductOrderController
{
    public class ProductOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public ProductOrderController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<PedidoDeProducto> productOrderList = _unitOfWork.PedidoDeProducto.GetAll();
            return View(productOrderList);

        }


        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        public IActionResult Create([FromBody] PedidoDeProducto productOrder)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PedidoDeProducto.Add(productOrder);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria creada correctamente" });
            }
            TempData["success"] = "Pedido de producto agregado correctamente";
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

            var productOrder = _unitOfWork.PedidoDeProducto.GetFirstOrDefault(x => x.IDPedidoProducto == id, null);
            if (productOrder == null)
            {
                return NotFound(new { success = false, message = "Pedido de producto no encontrado" });
            }

            return RedirectToAction("Index");
        }


        // Works

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] PedidoDeProducto productOrder)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PedidoDeProducto.Update(productOrder);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Pedido de producto editado correctamente";
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
            var productOrder = _unitOfWork.PedidoDeProducto.GetAll();
            return Json(new { data = productOrder, success = true });
        }
    }
}
