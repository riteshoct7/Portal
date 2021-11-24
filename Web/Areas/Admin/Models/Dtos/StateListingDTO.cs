using System.ComponentModel.DataAnnotations;

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
        public int StateId { get; set; }        

        [Display(Name ="State Name")]
        public string StateName { get; set; }
        [Display(Name = "State Description")]
        public string StateDescription { get; set; }        
        public bool Enabled { get; set; }        
        public int CountryId { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        [Display(Name = "Country Description")]
        public string CountryDescription { get; set; }

        [Display(Name = "ISD Code")]
        public string ISDCode { get; set; }

        #endregion  
    }
}
