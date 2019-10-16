using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.ViewModel
{
    public class Base
    {
        public int? Status { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? CreatedIP { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public int? ModifiedIP { get; set; }
        public int? ApprovedBy { set; get; }
        public DateTime? ApprovedDate { set; get; }
        public int? ApprovedIP { get; set; }
    }
}
