using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioProveedor : IRepositorio<Proveedor>
    {
        void Update(Proveedor proveedor);

        //Proveedor GetLast();
    }
}
