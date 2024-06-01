using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioCategoria : IRepositorio<Categoria>
    {
        void Update(Categoria categoria);

        Categoria GetLast();
    }
}
