using System.ComponentModel.DataAnnotations;

namespace Audree.Ssa.Core.ViewModel
{
    public  class MaterialViewmodel
    {
        [Display(Name = "Material Code")]
        public string Materialcode { get; set; }

        [Display(Name = "Material Description")]
        public string MaterialDescription { get; set; }

        [Display(Name = "Material Group Name")]
        public string MaterialGroupName { get; set; }
    }
}
