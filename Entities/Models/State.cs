using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public  class State
    {
        #region Constructors
        public State()
        {

        }
        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        [Display(Name ="State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public string StateName { get; set; }

        [Display(Name = "State Description")]        
        public string StateDescription { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public List<City> Cities { get; set; }


        #endregion  
    }
}
