using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Audree.Ssa.Api.DTOs
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        
        public string SupplierName { get; set; }
     
        public string SupplierCode { get; set; }

    }
}
