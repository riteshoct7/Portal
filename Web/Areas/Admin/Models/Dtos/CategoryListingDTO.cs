using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.Models.Dtos
{
    public class CategoryListingDTO
    {

        #region Constructors
        public CategoryListingDTO()
        {

        }
        #endregion

        #region Fields

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name Required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool Enabled { get; set; }


        #endregion
    }
}
