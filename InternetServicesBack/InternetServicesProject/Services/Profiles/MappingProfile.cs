using AutoMapper;
using InternetServicesProj.Data.Model;
using InternetServicesProj.Services.DTOs;

namespace InternetServicesProj.Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
