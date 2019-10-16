using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Audree.Ssa.Api.DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}
