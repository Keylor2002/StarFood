using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StarFood.Controllers.ProductController
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

        public IActionResult Index(string searchString)
        {
            var productos = _unitOfWork.Producto.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                productos = productos.Where(p => p.Nombre.Contains(searchString) || p.IDProducto.ToString().Contains(searchString));
            }
            var producto = new Producto();
            LoadViewBags();
            return View(Tuple.Create(productos, producto));
        }

        public IActionResult Delete(string searchString)
        {
            var productos = _unitOfWork.Producto.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                productos = productos.Where(p => p.Nombre.Contains(searchString) || p.IDProducto.ToString().Contains(searchString));
            }
            var producto = new Producto();
            LoadViewBags();
            return View(Tuple.Create(productos, producto));
        }

        [HttpPost]
        public IActionResult DeletePOST(int id)
        {
            var producto = _unitOfWork.Producto.GetFirstOrDefault(u => u.IDProducto == id, null, null);
            if (producto == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Producto.Remove(producto);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Producto deleted successfully" });
        }

        private void LoadViewBags()
        {
            ViewBag.Categorias = _unitOfWork.Categoria.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.IDCategoria.ToString(),
                    Text = c.Nombre
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
