using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioFactura : IRepositorio<Factura>
    {
        void Update(Factura factura);
    }
}
