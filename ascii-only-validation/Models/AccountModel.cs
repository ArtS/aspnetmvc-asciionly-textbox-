using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FilerPrintableOnlyTextInput.Models
{
    public class AccountModel
    {
        [Required]
        [RegularExpression("[ -~]+", ErrorMessage = "Please use only printable English characters")]
        [Display(Name = "Account name")]
        public string AccountName { get; set; }
    }
}