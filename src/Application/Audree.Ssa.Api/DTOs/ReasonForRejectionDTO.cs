using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Audree.Ssa.Api.DTOs
{
    public class ReasonForRejectionDTO
    {
        public int Id { get; set; }

        [Display(Name = "Reason For Rejection Description")]
        public string Description { get; set; }
    }
}
