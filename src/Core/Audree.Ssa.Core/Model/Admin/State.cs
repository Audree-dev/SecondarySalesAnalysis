using Audree.Ssa.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Model.Admin
{
    [Table("Master", Schema = "Admin")]
    public class State : Base
    {
        public int Id { get; set; }
        [Display(Name = "State Code")]
        public string StateCode { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }
    }
}
