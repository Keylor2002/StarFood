using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace StarFood.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.Producto.GetAll(includeProperties: "Categoria");
            return View(products);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            Producto product = new Producto();
            ViewBag.Categorias = _unitOfWork.Categoria.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.IDCategoria.ToString(),
                    Text = c.Nombre
                }).ToList();
            ViewBag.UnidadesMedida = new SelectList(new[]
            {
                new { Value = "Kg", Text = "Kilogramo" },
                new { Value = "L", Text = "Litro" },
                new { Value = "Unidad", Text = "Unidad" }
            }, "Value", "Text");

            ViewBag.SuspendidoOptions = new SelectList(new[]
            {
                new { Value = "true", Text = "Sí" },
                new { Value = "false", Text = "No" }
            }, "Value", "Text");

            return PartialView("_CreateProduct", product);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Producto product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Producto agregado correctamente";
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = _unitOfWork.Categoria.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.IDCategoria.ToString(),
                    Text = c.Nombre
                }).ToList();
            ViewBag.UnidadesMedida = new SelectList(new[]
            {
                new { Value = "Kg", Text = "Kilogramo" },
                new { Value = "L", Text = "Litro" },
                new { Value = "Unidad", Text = "Unidad" }
            }, "Value", "Text");

            ViewBag.SuspendidoOptions = new SelectList(new[]
            {
                new { Value = "true", Text = "Sí" },
                new { Value = "false", Text = "No" }
            }, "Value", "Text");

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.Producto.GetFirstOrDefault(p => p.IDProducto == id, null);

            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = _unitOfWork.Categoria.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.IDCategoria.ToString(),
                    Text = c.Nombre
                }).ToList();
            ViewBag.UnidadesMedida = new SelectList(new[]
            {
                new { Value = "Kg", Text = "Kilogramo" },
                new { Value = "L", Text = "Litro" },
                new { Value = "Unidad", Text = "Unidad" }
            }, "Value", "Text");

            ViewBag.SuspendidoOptions = new SelectList(new[]
            {
                new { Value = "true", Text = "Sí" },
                new { Value = "false", Text = "No" }
            }, "Value", "Text");

            return PartialView("_EditProduct", product);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(Producto product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Producto editado correctamente";
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = _unitOfWork.Categoria.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.IDCategoria.ToString(),
                    Text = c.Nombre
                }).ToList();
            ViewBag.UnidadesMedida = new SelectList(new[]
            {
                new { Value = "Kg", Text = "Kilogramo" },
                new { Value = "L", Text = "Litro" },
                new { Value = "Unidad", Text = "Unidad" }
            }, "Value", "Text");

            ViewBag.SuspendidoOptions = new SelectList(new[]
            {
                new { Value = "true", Text = "Sí" },
                new { Value = "false", Text = "No" }
            }, "Value", "Text");

            return View(product);
        }

        public IActionResult GetAll()
        {
            var products = _unitOfWork.Producto.GetAll(includeProperties: "Categoria");
            return Json(new { data = products, success = true });
        }
    }
}
