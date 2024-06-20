using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioDetallePedido : Repositorio<Detalleorden>, IRepositorioDetallePedido
    {
        private StarfoodContext _db;

        public RepositorioDetallePedido(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Detalleorden detallePedido)
        {
            _db.DetallesPedido.Update(detallePedido);
        }
    }
}
