using Audree.Ssa.Core.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Contracts.Repositories.Admin
{
   public  interface IUserRepository
    {
         Task<User> Authenticate(string username, string password);
         Task<List<User>> GetAllAsync();
        User GetById(int id);
        Task< User> Create(User user, string password);
        Task Update(User user, string password = null);
        void Delete(int id);
    }
}
