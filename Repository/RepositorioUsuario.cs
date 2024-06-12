using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;
using StarFood.Utility;
using Microsoft.AspNetCore.Identity;

namespace StarFood.Repository
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        private StarfoodContext _db;

        public RepositorioUsuario(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Usuario obj)
        {
            var objFromDB = _db.Usuarios.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDB != null)
            {
                objFromDB.NombreUsuario = obj.NombreUsuario;
                objFromDB.Cedula = obj.Cedula;
                objFromDB.Email = obj.Email;
            }
        }
    }
}
