using AutoMapper;
using Entities.Models;
using Web.Areas.Admin.Models.Dtos;

namespace Web.Mapper
{
    public class PortalMappings :Profile
    {
        #region Constructors
        public PortalMappings()
        {
            CreateMap<Category, CategoryListingDTO>().ReverseMap();
            CreateMap<Country, CountryListingDTO>().ReverseMap();
        } 
        #endregion
    }
}
