using Audree.Ssa.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audree.Ssa.Core.Model.Admin
{
    [Table("Changepassword", Schema = "Admin")]

    public class Changepassword : Base
    {

        public int Id { get; set; }
        public int LoginId { get; set; }
            [Required(ErrorMessage = "Please provide old password", AllowEmptyStrings = false)]
            [DataType(DataType.Password)]
            [Display(Name = "Old Password")]
            public string oldPassword { get; set; }

            [Required(ErrorMessage = "Please provide new password", AllowEmptyStrings = false)]
            [DataType(DataType.Password)]
            
            [Display(Name = "New Password")]
            public string newPassword { get; set; }
            [Required(ErrorMessage = "Please provide confirm password", AllowEmptyStrings = false)]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [System.ComponentModel.DataAnnotations.Compare("newPassword", ErrorMessage = "The password and confirmation password do not match.")]
            public string confirmPassword { get; set; }

            [NotMapped]
            public virtual Passwordpolicy passwordpolicy { get; set; }
        }


    }

