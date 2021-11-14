using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Country
    {
        #region Constructors
        public Country()
        {

        }
        #endregion

        #region Fields

        [Key]
        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Country Name Required")]
        public string CountryName { get; set; }

        [Display(Name = "ISD Code")]
        [Required(ErrorMessage = "ISD Code Required")]
        public string ISDCode { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; }

        public List<State> States { get; set; }

        #endregion

    }
}
