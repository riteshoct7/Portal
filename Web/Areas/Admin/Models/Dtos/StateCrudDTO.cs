using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Areas.Admin.Models.Dtos
{
    public class StateCrudDTO
    {
        public int StateId { get; set; }

        [Display(Name = "State Name")]
        public string StateName { get; set; }

        [Display(Name = "State Description")]
        public string StateDescription { get; set; }

        public bool Enabled { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage =("Country Required"))]
        public int CountryId { get; set; }
        
        
     
     
        public IEnumerable<SelectListItem>? Countries { get; set; }
    }
}
