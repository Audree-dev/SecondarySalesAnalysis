using Audree.Ssa.Core.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audree.Ssa.Core.Model.Master
{
 
        [Table("Role", Schema = "Master")]
        public class Role : Base
        {
            public int Id { get; set; }

            [Display(Name = "Role Description")]
            public string RoleDescription { set; get; }
        }

 }

