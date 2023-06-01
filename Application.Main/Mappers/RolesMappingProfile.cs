using Application.DTO.Request;
using Application.DTO.Response;
using AutoMapper;
using Common;
using Domain.Entity.Bases.Response;
using Domain.Entity.V1;

namespace Application.Main.Mappers
{
    public class RolessMappingProfile:Profile
    {
        public RolessMappingProfile()
        {
            CreateMap<Company, CompanyRequestCreateDto>()
                .ReverseMap();

            CreateMap<Company, CompanyRequestEditDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Company>, BaseEntityResponse<CompanyResponseDto>>()
                .ReverseMap();

            CreateMap<Role, RolesResponseDto>()
                .ForMember(x => x.RoleId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.StateRole, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))

                .ReverseMap();
        }
    }
}
