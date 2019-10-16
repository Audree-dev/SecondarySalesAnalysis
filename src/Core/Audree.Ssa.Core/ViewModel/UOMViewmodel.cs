using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.ViewModel
{
    public class UOMViewmodel
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Code { get; set; }
        public int UOMStatus { get; set; }
    }
}
