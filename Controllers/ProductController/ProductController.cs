using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using StarFood.Models;
using StarFood.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using StarFood.Repository;

namespace StarFood.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var productos = _unitOfWork.Producto.GetAll();
            var producto = new Producto();
            LoadViewBags();
            return View(Tuple.Create(productos, producto));
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Add(producto);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Producto creado correctamente" });
            }

            LoadViewBags();
            return PartialView("_CreateProductoPartial", producto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound(new { success = false, message = "ID no proporcionado" });
            }

            var producto = _unitOfWork.Producto.GetFirstOrDefault(x => x.IDProducto == id, null);
            if (producto == null)
            {
                return NotFound(new { success = false, message = "Producto no encontrado" });
            }

            LoadViewBags();
            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Update(producto);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            LoadViewBags();
            return View(producto);
        }

        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Producto.GetAll(includeProperties: "Categoria,Proveedor");

            var formattedList = productList.Select(producto => new
            {
                IDProducto = producto.IDProducto,
                Nombre = producto.Nombre,
                CantidadExistente = producto.CantidadExistente,
                PrecioVenta = producto.PrecioVenta,
                UnidadMedida = producto.UnidadMedida,
                Suspendido = producto.Suspendido,
                Categoria = new
                {
                    IdCategoria = producto.Categoria.IDCategoria,
                    NombreCategoria = producto.Categoria.Nombre
                }
            });

            return Json(new { data = formattedList });
        }

        private void LoadViewBags()
        {
            ViewBag.Categorias = _unitOfWork.Categoria.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.IDCategoria.ToString(),
                    Text = c.Nombre
                }).ToList();

            ViewBag.Proveedores = _unitOfWork.Proveedor.GetAll()
                .Select(p => new SelectListItem
                {
                    Value = p.IDProveedor.ToString(),
                    Text = p.Empresa
                }).ToList();

            ViewBag.UnidadesMedida = new List<SelectListItem>
            {
                new SelectListItem { Value = "Kg", Text = "Kilogramo" },
                new SelectListItem { Value = "L", Text = "Litro" },
                new SelectListItem { Value = "Unit", Text = "Unidad" }
            };

            ViewBag.SuspendidoOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "true", Text = "Sí" },
                new SelectListItem { Value = "false", Text = "No" }
            };
        }
    }
}