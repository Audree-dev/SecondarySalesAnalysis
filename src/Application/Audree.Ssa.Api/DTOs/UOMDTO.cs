using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Audree.Ssa.Api.DTOs
{
    public class UOMDTO
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string FullName { get; set; }
        public int Code { get; set; }
        public int UOMStatus { get; set; }
    }
}
