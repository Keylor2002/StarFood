using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioPlatillo : IRepositorio<Platillo>
    {
        void Update(Platillo platillo);
    }
}
