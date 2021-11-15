using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LoginViewModel
    {
        #region Constructors
        public LoginViewModel()
        {
        
        }
        #endregion

        #region Fields

        [Display(Name = "Email")]
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress(ErrorMessage ="Please provide valid email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Display(Name ="Remember Me?")]
        public bool RememberMe { get; set; }

        #endregion

    }
}
