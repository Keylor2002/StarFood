using Microsoft.EntityFrameworkCore;
using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
    {
        private StarfoodContext _db;

        public RepositorioCategoria(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Categoria categoria)
        {
            _db.Categorias.Update(categoria);
        }

        public Categoria GetLast()
        {
            return _db.Categorias.OrderByDescending(p => p.IDCategoria).FirstOrDefault();
        }
    }
}
