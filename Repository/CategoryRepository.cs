using Microsoft.EntityFrameworkCore;
using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class CategoryRepository : repository<Categoria>, ICategoryRepository
    {
        private StarfoodContext _db;

        public CategoryRepository(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Categoria categoria)
        {
            _db.Categorias.Update(categoria);
        }
    }
}
