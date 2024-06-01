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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CategoryList()
        {
            List<Categoria> categoryList = _businessCategorias.GetCategories();
            return Json(new { data = categoryList });
        }

        [HttpPost]
        public JsonResult AddCategory(Categoria categoria)
        {
            bool result = _businessCategorias.AddCategory(categoria);
            return Json(new { success = result });
        }

        [HttpPost]
        public JsonResult UpdateCategory(Categoria categoria)
        {
            bool result = _businessCategorias.UpdateCategory(categoria);
            return Json(new { success = result });
        }

        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
            bool result = _businessCategorias.DeleteCategory(id);
            return Json(new { success = result });
        }
    }
}
