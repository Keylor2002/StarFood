using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositoryPaymentMethod : IRepository<MetodoPago>
    {
        void Update(MetodoPago metodoPago);
    }
}
