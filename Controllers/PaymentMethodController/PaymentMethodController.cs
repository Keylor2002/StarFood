using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.PaymentMethodController
{
    public class PaymentMethodController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;
        // GET: HomeController

        public PaymentMethodController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<MetodoPago> paymentMethodList = _unitOfWork.MetodoPago.GetAll();
            return View(paymentMethodList);
        }

        // GET: HomeController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] MetodoPago paymentMethod)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MetodoPago.Add(paymentMethod);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Metodo de pago creado correctamente" });
            }
            TempData["success"] = "Metodo de pago agregado correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        // GET: HomeController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _unitOfWork.MetodoPago.GetFirstOrDefault(x => x.IDMetodoPago == id, null);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] MetodoPago paymentMethod)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MetodoPago.Update(paymentMethod);
                _unitOfWork.Save();
            }
            TempData["success"] = "Metodo de pago editado correctamente";
            return RedirectToAction("Index");
        }

        public IActionResult GetAll()
        {
            var paymentMethod = _unitOfWork.MetodoPago.GetAll();
            return Json(new { data = paymentMethod, success = true });
        }

        //// GET: HomeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: HomeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
