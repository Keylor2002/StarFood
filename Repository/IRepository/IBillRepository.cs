using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IBillRepository : IRepository<Factura>
    {
        void Update(Factura factura);
    }
}
