using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        public string CityName { get; set; }

        [Display(Name = "City Description")]
        public string CityDescription { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public StateListingDTO State { get; set; }

        #endregion
    }
}
