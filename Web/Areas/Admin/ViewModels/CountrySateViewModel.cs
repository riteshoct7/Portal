using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Web.Areas.Admin.Models.Dtos;

namespace Web.Areas.Admin.ViewModels
{
    public class CountrySateViewModel
    {
        public StateListingDTO StateListingDTO { get; set; }
               
        public IEnumerable<SelectListItem> Countries { get; set; }

        [Display(Name = "Country")]
        public string CountryName { get; set; }
    }
}
