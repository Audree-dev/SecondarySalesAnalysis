using Audree.Ssa.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Model.Master
{
    [Table("Supplier", Schema = "Master")]
    public class Supplier: Base
    {

        public int Id { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Display(Name = "Supplier Code")]
        public string SupplierCode { get; set; }

    }
}
