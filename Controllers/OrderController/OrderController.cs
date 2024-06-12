using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.OrderController
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public OrderController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<Pedido> orderList = _unitOfWork.Pedido.GetAll();
            return View(orderList);
        }


        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        public IActionResult Create([FromBody] Pedido order)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Pedido.Add(order);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Pedido creado correctamente" });
            }
            TempData["success"] = "Nuevo pedido realizado";
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

            var order = _unitOfWork.Pedido.GetFirstOrDefault(x => x.IDPedido == id, null);
            if (order == null)
            {
                return NotFound(new { success = false, message = "Pedido no encontrado" });
            }

            return Json(new { success = true, data = order });
        }


        // Works

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] Pedido order)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Pedido.Update(order);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Pedido editado correctamente";
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
            var orderList = _unitOfWork.Pedido.GetAll(includeProperties: "DetallePedido.Platillo,Usuario");

            var formattedList = orderList.Select(pedido => new
            {
                IDPedido = pedido.IDPedido,
                FechaPedido = pedido.FechaPedido,
                FechaEntrega = pedido.FechaEntrega,
                Cancelado = pedido.Cancelado,
                EnProceso = pedido.EnProceso,
                Entregado = pedido.Entregado,
                Usuario = new
                {
                    Id = pedido.Usuario.Id,
                    UserName = pedido.Usuario.UserName
                },

                DetallePedido = pedido.DetallePedido.Select(detalle => new
                {
                    IDDetallePedido = detalle.IDDetallePedido,
                    IDPedido = detalle.IDPedido,
                    IDPlatillo = detalle.IDPlatillo,
                    Platillo = new
                    {
                        IDPlatillo = detalle.Platillo.IDPlatillo,
                        Nombre = detalle.Platillo.Nombre // Asumiendo que la entidad Platillo tiene una propiedad Nombre
                    },
                    Cantidad = detalle.Cantidad
                }).ToList()
            }).ToList();

            return Ok(new { data = formattedList });
        }
    }
}
    


