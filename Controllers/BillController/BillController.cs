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
                
                decimal totalventa = 0;
                if (bill.Pedido != null && bill.Pedido.DetallePedido != null)
                {
                    foreach (var detalle in bill.Pedido.DetallePedido)
                    {
                       totalventa += (detalle.Platillo.Precio * detalle.Cantidad);
                    }
                }
                bill.TotalVenta = totalventa;
                bill.CantidadCambio = bill.CantidadPago - bill.TotalVenta;
                bill.FechaVenta = DateTime.Now;

                _unitOfWork.Factura.Add(bill);
                _unitOfWork.Save();
                TempData["success"] = "Factura pagada";
                return Json(new { success = true, message = totalventa });
            }

            // En caso de que el ModelState no sea válido
            TempData["error"] = "Error en los datos de la factura";
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        public IActionResult GetAll()
        {
            var BillList = _unitOfWork.Factura.GetAll(includeProperties: "Pedido,Pedido.DetallePedido,Pedido.DetallePedido.Platillo");

            var formattedList = BillList.Select(factura => new
            {
                IDFactura = factura.IDFactura,
                IDPedido = factura.IDPedido,
                factura.CantidadCambio,
                factura.CantidadPago,
                factura.TotalVenta,
                factura.FechaVenta,
                Pedido = new
                {
                    factura.Pedido.IDPedido,
                    DetallePedido = factura.Pedido.DetallePedido.Select(detalle => new
                    {
                        detalle.Cantidad,
                        Platillo = new
                        {
                            detalle.Platillo.Precio
                        }
                    }).ToList()
                }
            }).ToList();

            return Json(new { data = formattedList });
        }
    }
}
