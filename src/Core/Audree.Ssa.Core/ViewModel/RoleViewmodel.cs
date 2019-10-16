using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.ViewModel
{
   public class RoleViewmodel
    {
        [Display(Name = "Role Description")]
        public string RoleDescription { set; get; }
    }
}
