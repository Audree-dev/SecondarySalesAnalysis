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
  
    [Table("SmtpPasswordConfig", Schema = "Admin")]

    public class SmtpPasswordConfig : Base
    {
     
        public int Id { get; set; }

        [Display(Name = "Password Type")]
        public bool PasswordType { get; set; } //Random-True,Fixed -False
        [DataType(DataType.Password)]
        [Display(Name = "Default  Password")]
        public string DefaultPassword { get; set; }// For New user
        [Display(Name = "Smtp Server")]
        public string SmtpServer { get; set; }
        [Display(Name = "Smtp Port No.")]
        public string SmtpPortNumber { get; set; }
        [Display(Name = "From Mail Id")]
        public string FromMailId { get; set; }
        [Display(Name = "Smtp User")]
        public string SmtpUser { get; set; }
        [DataType(DataType.Password)]

        [Display(Name = "Smtp User Password")]
        public string SmtpUserPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Smtp Confirm Password")]
        public string ConfirmUserPassword { get; set; }

        [Display(Name = "SSL Enable")]
        public bool SSLEnable { get; set; }

    }
}
