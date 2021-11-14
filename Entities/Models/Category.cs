using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public  class Category
    {
        #region Constructors
        public Category()
        {

        }
        #endregion

        #region Fields

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Category Name Required")]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool Enabled { get; set; }

        public List<Product> Products { get; set; }


        #endregion
    }
}
