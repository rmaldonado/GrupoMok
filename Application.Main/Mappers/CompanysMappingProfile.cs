using Application.DTO.Request;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entity.Bases.Response;
using Domain.Entity.V1;

namespace Application.Main.Mappers
{
    public class CompanysMappingProfile:Profile
    {
        public CompanysMappingProfile()
        {
            CreateMap<Company, CompanyRequestCreateDto>()
                .ReverseMap();

            CreateMap<Company, CompanyRequestEditDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Company>, BaseEntityResponse<CompanyResponseDto>>()
                .ReverseMap();

            CreateMap<Company, CompanyResponseDto>()
                .ForMember(x => x.CompanyId, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
