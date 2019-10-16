using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audree.Ssa.Core.Model.Admin;
using Audree.Ssa.Core.Model.Master;

namespace Audree.Ssa.Api.DTOs
{
    public class UsersInRolesDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
