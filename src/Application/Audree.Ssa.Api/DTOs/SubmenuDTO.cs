using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Audree.Ssa.Api.DTOs
{
    public class SubmenuDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
