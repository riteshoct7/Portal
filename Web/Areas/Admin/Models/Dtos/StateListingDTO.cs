using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Areas.Admin.Models.Dtos
{
    public class StateListingDTO
    {
        #region Constructors
        public StateListingDTO()
        {

        }
        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public string StateName { get; set; }

        [Display(Name = "State Description")]
        public string StateDescription { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; }

        
        [Display(Name ="Country")]
        [Required(ErrorMessage ="Country Required")]
        public int CountryId { get; set; }

        //public CountryListingDTO Country { get; set; }

        //public List<CityListingDTO> Cities { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [Display(Name ="Country")]
        public string CountryName { get; set; }

        #endregion  
    }
}
