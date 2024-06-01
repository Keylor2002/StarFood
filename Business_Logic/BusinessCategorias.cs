using StarFood.Data;
using StarFood.Models;
using System.Collections.Generic;

namespace StarFood.Business_Logic
{
    public class BusinessCategorias
    {
        private readonly DataCategory _dataCategory;

        public BusinessCategorias(DataCategory dataCategory)
        {
            _dataCategory = dataCategory;
        }

        public List<Categoria> GetCategories()
        {
            return _dataCategory.CategoryList();
        }

        public bool AddCategory(Categoria categoria)
        {
            // Aquí puedes agregar lógica de negocio adicional antes de añadir la categoría.
            return _dataCategory.AddCategory(categoria);
        }

        public bool UpdateCategory(Categoria categoria)
        {
            // Aquí puedes agregar lógica de negocio adicional antes de actualizar la categoría.
            return _dataCategory.UpdateCategory(categoria);
        }

        public bool DeleteCategory(int id)
        {
            // Aquí puedes agregar lógica de negocio adicional antes de eliminar la categoría.
            return _dataCategory.DeleteCategory(id);
        }
    }
}
