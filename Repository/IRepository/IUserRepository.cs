using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IUserRepository : IRepository<Usuario>
    {
        void Update(Usuario obj);
    }
}

