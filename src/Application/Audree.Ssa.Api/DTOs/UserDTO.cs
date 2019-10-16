using System.ComponentModel.DataAnnotations;
using Audree.Ssa.Core.Model.Master;

namespace Audree.Ssa.Api.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
