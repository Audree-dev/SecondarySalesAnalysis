using Audree.Ssa.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Model.Master
{
   public class Country:Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Country Code")]
        public string CountryCode { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
    }
}
