
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.ViewModels
{
    public class LoginVM
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }


}
