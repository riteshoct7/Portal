using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class ApplicationUser: IdentityUser<int>
    {

        #region Constructors
        public ApplicationUser()
        {

        }
        #endregion

        #region Fields

        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; } 

        #endregion
    }
}
