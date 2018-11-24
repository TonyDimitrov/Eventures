using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.ViewModels
{
    public class RegisterVM : LoginVM
    {
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [MinLength(4)]
        public string ConfirmPassword { get; set; }
        [Display(Name = "First Name")]
        public string FirstName  { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "UCN")]
        [MinLength(6)]
        public string Ucn { get; set; }
    }
}
