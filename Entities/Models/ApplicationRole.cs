using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public  class ApplicationRole : IdentityRole<int>
    {
        #region Constructors
        public ApplicationRole()
        {

        }
        #endregion

        #region Fields

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; } 

        #endregion
    }
}
