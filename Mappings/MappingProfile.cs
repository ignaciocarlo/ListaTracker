using AutoMapper;
using ListaTracker.Entities;
using ListaTracker.Models;

namespace ListaTracker.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CategoryViewModel, Category>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
