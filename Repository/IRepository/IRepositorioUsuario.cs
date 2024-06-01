using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        void Update(Usuario obj);
    }
}

