﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Controllers.DishController
{
    public class DishController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public DishController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<Platillo> DishList = _unitOfWork.Platillo.GetAll();
            return View(DishList);
            
        }


        public IActionResult Create()
        {
            return View();
        }

        // Works
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Platillo platillo)
        {
            if (ModelState.IsValid)
            {

                var categoriaExistente = _unitOfWork.Categoria.GetFirstOrDefault(c => c.IDCategoria == platillo.CategoriaID, null);
                if (categoriaExistente == null)
                {
                    return BadRequest("Categoría no encontrada.");
                }


                _unitOfWork.Platillo.Add(platillo);
                _unitOfWork.Save();

                //return Json(new { success = true, message = "Platillo creado correctamente" });
            }
            TempData["success"] = "Platillo creado correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        // Works
        //[HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound(new { success = false, message = "ID no proporcionado" });
            }

            var platillo = _unitOfWork.Platillo.GetFirstOrDefault(x => x.IDPlatillo == id, null);
            if (platillo == null)
            {
                return NotFound(new { success = false, message = "Platillo no encontrado" });
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Platillo platillo)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Platillo.Update(platillo);
                _unitOfWork.Save();
                //return Json(new { success = true, message = "Categoria actualizada correctamente" });
            }
            TempData["success"] = "Platillo editada correctamente";
            return RedirectToAction("Index");
            //return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }


        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    var CategoryToDelete = _unitOfWork.Categoria.Get(u => u.IDCategoria == id);

        //    if (CategoryToDelete == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting category" });
        //    }

        //    _unitOfWork.Categoria.Remove(CategoryToDelete);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Category deleted successfully" });
        //}

        //public IActionResult Suspend(int? id)
        //{

        //    var category = _unitOfWork.Categoria.GetFirstOrDefault(x => x.IDCategoria == id, null);

        //    if (category.Suspendido == false)
        //    {
        //        category.Suspendido = true;
        //        TempData["success"] = "Categoria suspendida correctamente";
        //    }
        //    else
        //    {
        //        category.Suspendida = false;
        //        TempData["success"] = "La categoria se activo correctamente";
        //    }
        //    _unitOfWork.Categoria.Update(category);
        //    _unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}


        // Works
        public IActionResult GetAll()
        {
            //var DishList = _unitOfWork.Platillo.GetAll(includeProperties: "Categoria");

            //var formattedList = DishList.Select(platillo => new
            //{
            //    IDPlatillo = platillo.IDPlatillo,
            //    Nombre = platillo.Nombre,
            //    Precio = platillo.Precio,
            //    Descripcion = platillo.Descripcion,
            //    Suspendido = platillo.Suspendido,
            //    ImagenUrl = platillo.ImagenUrl,
            //    Categoria = new
            //    {
            //        IdCategoria = platillo.Categoria.IDCategoria,
            //        NombreCategoria = platillo.Categoria.Nombre
            //    }
            //});
            var dish = _unitOfWork.Categoria.GetAll();
            return Json(new { data = dish, success = true });
            //return Json(new { data = formattedList });
        }
    }
}