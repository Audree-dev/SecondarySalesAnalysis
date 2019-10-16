using Audree.Ssa.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Model.Master
{
    [Table("UOM", Schema = "Master")]
    public class UOM:Base
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string FullName { get; set; }
        public int Code { get; set; }
        public int UOMStatus { get; set; }
    }
}
