using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Audree.Ssa.Api.DTOs
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Materialcode { get; set; }
        public string MaterialDescription { get; set; }
        public string MaterialGroupName { get; set; }
    }
}
