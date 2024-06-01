using StarFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using StarFood.Data;

namespace StarFood.Business_Logic
{
    public class BusinessCategorias
    {
        private readonly StarfoodContext _context;

        public BusinessCategorias()
        {
            _context = new StarfoodContext(); // Initialize the DbContext
        }

        // Return the Category List
        public List<Categoria> CategoryList()
        {
            return _context.Categorias.ToList();
        }

        // Create a new Category
        public void CreateCategory(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public void SaveCategory(Categoria categoria)
        {
            _context.SaveChanges();
        }

        // Método para actualizar una categoría existente
        public void UpdateCategory(Categoria categoria)
        {
            var existingCategory = _context.Categorias.Find(categoria.IDCategoria);
            if (existingCategory != null)
            {
                existingCategory.Nombre = categoria.Nombre;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Categoría no encontrada");
            }
        }

        // Método para eliminar una categoría
        public void DeleteCategory(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Categoría no encontrada");
            }
        }
    }
}