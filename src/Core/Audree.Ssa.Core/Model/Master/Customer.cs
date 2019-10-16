using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audree.Ssa.Core.Model.Master
{
    [Table("Customer", Schema = "Master")]
    public  class Customer 
    {
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }
        [Display(Name = "Customer Address")]
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public int? Status { get; set; }
    }
}
