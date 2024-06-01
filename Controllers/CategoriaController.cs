using Microsoft.AspNetCore.Mvc;
using StarFood.Business_Logic;
using StarFood.Models;
using System.Collections.Generic;

namespace StarFood.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly BusinessCategorias _businessCategorias;

        public CategoriasController(BusinessCategorias businessCategorias)
        {
            _businessCategorias = businessCategorias;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CategoryList()
        {
            List<Categoria> categoryList = _businessCategorias.CategoryList();
            return Json(new { data = categoryList });
        }

        [HttpPost]
        public JsonResult CreateCategory([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _businessCategorias.AddCategory(categoria);
                return Json(new { success = true, message = "Categoría creada correctamente." });
            }
            return Json(new { success = false, message = "Datos inválidos." });
        }

        [HttpPut]
        public JsonResult UpdateCategory([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _businessCategorias.UpdateCategory(categoria);
                return Json(new { success = true, message = "Categoría actualizada correctamente." });
            }
            return Json(new { success = false, message = "Datos inválidos." });
        }

        [HttpDelete]
        public JsonResult DeleteCategory(int id)
        {
            _businessCategorias.DeleteCategory(id);
            return Json(new { success = true, message = "Categoría eliminada correctamente." });
        }
    }
}