using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IDishRepository : IRepository<Platillo>
    {
        void Update(Platillo platillo);
    }
}
