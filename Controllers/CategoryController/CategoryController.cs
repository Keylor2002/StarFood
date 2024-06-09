﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.CategoryController
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        
        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            //IEnumerable<Categoria> categoryList = _unitOfWork.Categoria.GetAll();
            //return View(categoryList);
            return View();
        }

        
        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        public IActionResult Create([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Add(categoria);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria creada correctamente" });
            }
            TempData["success"] = "Categoria creada correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        // Works
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound(new { success = false, message = "ID no proporcionado" });
            }

            var categoria = _unitOfWork.Categoria.GetFirstOrDefault(x => x.IDCategoria == id, null);
            if (categoria == null)
            {
                return NotFound(new { success = false, message = "Categoría no encontrada" });
            }

            return Json(new { success = true, data = categoria });
        }


        // Works

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] Categoria category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Update(category);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Categoria editada correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CategoryToDelete = _unitOfWork.Categoria.Get(u => u.IDCategoria == id);

            if (CategoryToDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting category" });
            }

            _unitOfWork.Categoria.Remove(CategoryToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Category deleted successfully" });
        }


        // Works
        public IActionResult GetAll()
        {
            var category = _unitOfWork.Categoria.GetAll();
            return Json(new { data = category, success = true });
        }
    }
}
