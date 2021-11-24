using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models.Dtos
{
    public class CityListingDTO
    {

        #region Constructors
        public CityListingDTO()
        {

        }
        #endregion

        #region Fields        
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        public string CityDescription { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; }
        
        public int StateId { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }

        public int CountryId { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        [Display(Name = "CountryDescription")]
        public string CountryDescription { get; set; }

        [Display(Name = "State Description")]
        public string StateDescription { get; set; }

        [Display(Name = "ISD Code")]
        public string ISDCode { get; set; }

        #endregion

    }
}
