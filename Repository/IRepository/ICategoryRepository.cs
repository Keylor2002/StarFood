using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);
    }
}
