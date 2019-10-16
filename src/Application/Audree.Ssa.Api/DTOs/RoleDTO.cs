using System.ComponentModel.DataAnnotations;

namespace Audree.Ssa.Api.DTOs
{
    public class RoleDTO 
    {
        public int Id { get; set; }

        [Display(Name = "Role Description")]
        public string RoleDescription { set; get; }
    }
}
