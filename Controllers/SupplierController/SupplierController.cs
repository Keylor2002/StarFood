using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.SupplierController
{
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;
        // GET: HomeController

        public SupplierController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Proveedor> supplierList = _unitOfWork.Proveedor.GetAll();
            return View(supplierList);
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proveedor supplier)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Proveedor.Add(supplier);
                _unitOfWork.Save();
            }
            TempData["success"] = "Proveedor agregado correctamente";
            return RedirectToAction("Index");
        }

        // GET: HomeController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _unitOfWork.Proveedor.GetFirstOrDefault(x => x.IDProveedor == id, null);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Proveedor supplier)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Proveedor.Update(supplier);
                _unitOfWork.Save();
            }
            TempData["success"] = "Proveedor editado correctamente";
            return RedirectToAction("Index");
        }

        public IActionResult GetAll()
        {
            var supplier = _unitOfWork.Proveedor.GetAll();
            return Json(new {data = supplier, success = true});
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
