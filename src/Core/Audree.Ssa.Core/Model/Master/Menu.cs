using Audree.Ssa.Core.Model.Admin;
using System.ComponentModel.DataAnnotations.Schema;


namespace Audree.Ssa.Core.Model.Master
{
    [Table("Menu", Schema = "Admin")]
    public class Menu 
    {
            public int Id { get; set; }
            public string LinkText { get; set; }
            public string Action { get; set; }
            public string Controller { get; set; }
            
            public int ProfileId { get; set; }

            public virtual ProfilesMaster ProfilesMasters { get; set; }
        
            public int? MenuOrder { get; set; }

            public bool DefaultMenu { get; set; }
            public bool Active { get; set; }

            public string Icon { get; set; }
            [NotMapped]
            public int? MenuId { get; set; }
            [NotMapped]
            public int? RoleId { get; set; }
            [NotMapped]
            public int? TempId { get; set; }

    }
}
