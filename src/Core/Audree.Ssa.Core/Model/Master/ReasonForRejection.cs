using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audree.Ssa.Core.Model.Master
{
    [Table("ReasonForRejection", Schema = "Master")]
   public class ReasonForRejection
    {
        public int Id { get; set; }

        [Display(Name = "Reason For Rejection Description")]
        public string Description { get; set; }
    }
}
