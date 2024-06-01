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
            _context = new StarfoodContext(); // Inicializa tu contexto de datos
        }

        // Método para obtener la lista de categorías
        public List<Categoria> CategoryList()
        {
            return _context.Categorias.ToList();
        }

        // Método para agregar una nueva categoría
        public void AddCategory(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
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