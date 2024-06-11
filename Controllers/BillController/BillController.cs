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
                if (bill.Pedido.DetallePedido != null)
                {
                    for (int j = 0; j < bill.Pedido.DetallePedido.Count(); j++)
                    {
                        var aux = bill.Pedido.DetallePedido.ElementAt(j);
                        bill.TotalVenta += aux.Platillo.Precio * aux.Cantidad;
                    }
                }
                bill.CantidadCambio = (bill.TotalVenta - bill.CantidadPago);
                bill.FechaVenta = DateTime.Now;

                _unitOfWork.Factura.Add(bill);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria creada correctamente" });
            }
            TempData["success"] = "Factura pagada";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
        public IActionResult GetAll()
        {
            var bill = _unitOfWork.Factura.GetAll();
            return Json(new { data = bill, success = true });
        }
    }
}
