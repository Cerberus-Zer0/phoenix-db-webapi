using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class InstitutionsProfile : Profile
    {
        public InstitutionsProfile()
        {
            CreateMap<Institution, InstitutionReadDto>();
            CreateMap<InstitutionCreateDto, Institution>();
            CreateMap<InstitutionUpdateDto, Institution>();
            CreateMap<Institution, InstitutionUpdateDto>();
        }
    }
}