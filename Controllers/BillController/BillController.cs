using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.BillController
{
    public class BillController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public BillController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        public IActionResult Create([FromBody] Factura bill)
        {
            if (ModelState.IsValid)
            {
                Orden pedido = _unitOfWork.Pedido.GetFirstOrDefault(x => x.IDPedido == bill.IDPedido, null);
                //decimal totalventa = 0;
                if (pedido != null && pedido.DetallePedido != null)
                {
                    foreach (var detalle in pedido.DetallePedido)
                    {
                       bill.TotalVenta += (detalle.Platillo.Precio * detalle.Cantidad);
                    }
                }
                //bill.TotalVenta = totalventa;
                bill.CantidadCambio = bill.CantidadPago - bill.TotalVenta;
                bill.FechaVenta = DateTime.Now;

                _unitOfWork.Factura.Add(bill);
                _unitOfWork.Save();
                TempData["success"] = "Factura pagada";
                return Json(new { success = true, message = "Add correctly" });
            }

            // En caso de que el ModelState no sea válido
            TempData["error"] = "Error en los datos de la factura";
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        public IActionResult GetAll()
        {
            var bill = _unitOfWork.Factura.GetAll();
            return Json(new { data = bill, success = true });
        }
    }
}
