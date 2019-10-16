using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.ViewModel
{
    public class MenuViewmodel
    {
        public string LinkText { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }

        public int ProfileId { get; set; }

        // public virtual Profiles Profile { get; set; }

        public int? MenuOrder { get; set; }

        public bool DefaultMenu { get; set; }
        public bool Active { get; set; }

        public string Icon { get; set; }
        public int? MenuId { get; set; }
        public int? RoleId { get; set; }
        public int? TempId { get; set; }

    }
}
