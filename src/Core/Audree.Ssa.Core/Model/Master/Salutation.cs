using Audree.Ssa.Core.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audree.Ssa.Core.Model.Master
{
    [Table("Salutation", Schema = "Master")]
    public class Salutation : Base
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
