using Audree.Ssa.Core.ViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audree.Ssa.Core.Model.Admin
{
    [Table("PasswordPolicy", Schema = "Admin")]
    public class Passwordpolicy : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Password Expiry")]
        public int PasswordExpiry { get; set; }
        [Display(Name = "Invalid Attempts")]
        public int InvalideAttempts { get; set; }
        [Display(Name = "Minimum Length")]
        public int MinimumLength { get; set; }
        [Display(Name = "Minimum UpperCase Characters")]
        public int MinimumUpperCaseCharacters { get; set; }
        [Display(Name = "Minimum LowerCase Characters")]
        public int MinimumLowerCaseCharacters { get; set; }
        [Display(Name = "Minimum Digits")]
        public int MinimumDigits { get; set; }
        [Display(Name = "Minimum Special Characters")]
        public int MinimumSpecialCharacters { get; set; }
        [Display(Name = "Password Expiry Alert Before")]
        public int PasswordExpiryAlertBeforeDays { get; set; }
        [Display(Name = "Enforce Password History")]
        public int EnforcePasswordHistory { get; set; }
        public bool Active { get; set; }

    }
}
