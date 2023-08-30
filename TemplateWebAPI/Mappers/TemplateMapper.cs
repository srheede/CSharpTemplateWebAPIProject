using AutoMapper;
using TemplateWebAPI.Models;

namespace TemplateWebAPI.Mappers
{
    public class TemplateMapper : Profile
    {
        public TemplateMapper() {

            CreateMap<TemplateModel, TemplateModelDTO>();

            CreateMap<TemplateModelDTO, TemplateModel>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
