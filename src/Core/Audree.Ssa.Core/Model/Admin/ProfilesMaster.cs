using Audree.Ssa.Core.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audree.Ssa.Core.Model.Admin
{
    [Table("ProfilesMaster", Schema = "Admin")]
    public class ProfilesMaster : Base
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

    }
}