using Application.DTO.Request;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entity.V1;
using Infraestructure.Commons.Base.Response;

namespace Application.Main.Mappers
{
    public class MenuMappingProfile: Profile {
        public MenuMappingProfile() {

            CreateMap<Menu, MenuRequestCreateDto>()
                .ReverseMap();

            CreateMap<Menu, MenuRequestEditDto>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<Menu>, BaseEntityResponse<MenuResponseDto>>()
                .ReverseMap();

            CreateMap<Menu, MenuResponseDto>()
                .ForMember(x => x.MenuId, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
