using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IDetailDishRepository : IRepository<DetallePlatillo>
    {
        void Update(DetallePlatillo detalle_Platillo);
    }
}
