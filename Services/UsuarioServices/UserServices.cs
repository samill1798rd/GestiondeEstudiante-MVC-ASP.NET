using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly GestionDB _gestionDB;
        public UserServices()
        {
            _gestionDB = new GestionDB();
        }

        public Usuario GetFirst(Expression<Func<Usuario, bool>> query)
            => _gestionDB.Usuarios.FirstOrDefault(query);

        public IEnumerable<Usuario> GetAllUsers()
            => _gestionDB.Usuarios
                        .OrderBy(x => x.NombreUsuario)
                        .Where(x => x.IsActive == true)
                        .AsQueryable();
        

        public Usuario GetUserById(int id)
            => _gestionDB.Usuarios.Find(id);

        public OperationResult<Usuario> SaveUser(Usuario model)
        {
            OperationResult<Usuario> operation;

            try
            {
                _gestionDB.Usuarios.Add(model);
                _gestionDB.SaveChanges();
                operation = SendModelStatus(model, true);
            }
            catch (Exception)
            {
                operation = SendModelStatus(model, false);
            }

            return operation;
        }

        public OperationResult<Usuario> UpdateUser(Usuario model)
        {
            var operation = new OperationResult<Usuario>();

            var UserTracking = _gestionDB.Usuarios.SingleOrDefault(x => x.Id_usuario.Equals(model.Id_usuario));
            try
            {
                _gestionDB.Usuarios.Attach(model);
                _gestionDB.Entry(model).State = EntityState.Modified;
                _gestionDB.SaveChanges();
                operation = SendModelStatus(model, true);
            }
            catch (Exception)
            {
                operation = SendModelStatus(model, false);
            }
            return operation;
        }

        public OperationResult<Usuario> DisableUser(Usuario model)
        {
            var UserTracking = _gestionDB.Usuarios.Find(model.Id_usuario);
            OperationResult<Usuario> operation;

            try
            {
                UserTracking.IsActive = model.IsActive;
                _gestionDB.SaveChanges();
                operation = SendModelStatus(model, true);
            }
            catch (Exception)
            {
                operation = SendModelStatus(model, false);
            }
            return operation;
        }

        private OperationResult<Usuario> SendModelStatus(Usuario model, bool status)
        {
            var operation = new OperationResult<Usuario>();
            operation.Mensaje.Add(status.Equals(true) ? "Success" : "Error");
            operation.ResultObject = model;
            operation.Ok = status;

            return operation;
        }
    }
}

