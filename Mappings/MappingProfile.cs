using AutoMapper;
using ListaTracker.Entities;
using ListaTracker.Features.Categories.Commands;
using ListaTracker.Models;

namespace ListaTracker.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CategoryViewModel, CreateCategoryCommand>();
            CreateMap<CategoryViewModel, UpdateCategoryCommand>();
            CreateMap<CategoryViewModel, DeleteCategoryCommand>();
            CreateMap<CategoryViewModel, Category>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
