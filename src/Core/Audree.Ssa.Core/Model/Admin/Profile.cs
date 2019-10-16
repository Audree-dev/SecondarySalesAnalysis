using Audree.Ssa.Core.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audree.Ssa.Core.Model.Admin
{
    [Table("Profile", Schema = "Admin")]
    public class Profile : Base
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    
    
    }
}
