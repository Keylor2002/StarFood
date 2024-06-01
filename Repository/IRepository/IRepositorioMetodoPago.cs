using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioMetodoPago : IRepositorio<MetodoPago>
    {
        void Update(MetodoPago metodoPago);
    }
}
