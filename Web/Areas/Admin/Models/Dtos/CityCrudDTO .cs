using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models.Dtos
{
    public class CityCrudDTO
    {
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage ="City Name Required")]
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        [Required(ErrorMessage = "City Description Required")]
        public string CityDescription { get; set; }

        public bool Enabled { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = ("State Required"))]
        public int StateId { get; set; }

        public IEnumerable<SelectListItem>? States { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage =("Country Required"))]
        public int CountryId { get; set; }
                       
        public IEnumerable<SelectListItem>? Countries { get; set; }
    }
}
