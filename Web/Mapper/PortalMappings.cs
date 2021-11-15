using AutoMapper;
using Entities.Models;
using Web.Areas.Admin.Models.Dtos;
using Web.Models;

namespace Web.Mapper
{
    public class PortalMappings :Profile
    {
        #region Constructors
        public PortalMappings()
        {
            CreateMap<Category, CategoryListingDTO>().ReverseMap();
            CreateMap<Country, CountryListingDTO>().ReverseMap();
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
        } 
        #endregion
    }
}
