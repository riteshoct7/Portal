using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
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
            CreateMap<Product, ProductListingDTO>().ReverseMap();
            CreateMap<Country, CountryListingDTO>().ReverseMap();
            CreateMap<State, StateListingDTO>().ReverseMap();
            CreateMap<City, CityListingDTO>().ReverseMap();
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
            CreateMap<ApplicationUser, LoginViewModel>().ReverseMap();
            CreateMap<ApplicationRole, ApplicationRoleDTO>().ReverseMap();            
            CreateMap<State, StateCrudDTO>().ReverseMap();
            CreateMap<City, CityCrudDTO>().ReverseMap();
        } 
        #endregion
    }
}
