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
    [Table("Material", Schema = "Master")]
    public class Material : Base
    {
        public int Id { get; set; }

        [Display(Name = "Material code")]
        public string Materialcode { get; set; }

        [Display(Name = "Material Description")]
        public string MaterialDescription { get; set; }

        [Display(Name = "Material Group Name")]
        public string MaterialGroupName { get; set; }

    }
}
