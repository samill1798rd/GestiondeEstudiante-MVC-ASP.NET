using Common;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.UserServices
{
    public interface IUserServices
    {
        Usuario GetFirst(Expression<Func<Usuario, bool>> query);
        IEnumerable<Usuario> GetAllUsers();
        Usuario GetUserById(int id);
        OperationResult<Usuario> SaveUser(Usuario model);
        OperationResult<Usuario> UpdateUser(Usuario model);
    }
}
