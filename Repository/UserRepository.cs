using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;
using StarFood.Utility;
using Microsoft.AspNetCore.Identity;

namespace StarFood.Repository
{
    public class UserRepository : repository<Usuario>, IUserRepository
    {
        private StarfoodContext _db;

        public UserRepository(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Usuario obj)
        {
            var objFromDB = _db.Usuarios.FirstOrDefault(u => u.IDUsuario == obj.IDUsuario);
            if (objFromDB != null)
            {
                objFromDB.NombreUsuario = obj.NombreUsuario;
                objFromDB.IDUsuario = obj.IDUsuario;
                objFromDB.Email = obj.Email;
            }
        }
    }
}
