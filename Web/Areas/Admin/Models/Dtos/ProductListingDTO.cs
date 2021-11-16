using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Areas.Admin.Models.Dtos
{
    public class ProductListingDTO
    {
        #region Properties
        public ProductListingDTO()
        {

        }
        #endregion

        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Productid { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price Required")]
        public double Price { get; set; }

        public bool Enabled { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryListingDTO Category { get; set; }

        #endregion
    }
}
