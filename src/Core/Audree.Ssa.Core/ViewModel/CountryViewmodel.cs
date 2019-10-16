using Audree.Ssa.Core.Model.Master;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.ViewModel
{
    public class CountryViewmodel
    {
        
        public int Id { get; set; }
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
      
    }
}

