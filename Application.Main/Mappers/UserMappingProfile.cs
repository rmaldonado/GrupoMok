using Application.DTO.Request;
using Application.DTO.Response;
using AutoMapper;
using Common;
using Domain.Entity.V1;
using Infraestructure.Commons.Base.Response;

namespace Application.Main.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserResponseDto>()
                .ForMember(x => x.UserId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.StateUser, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<User, UserRequestCreate>()
               .ReverseMap();

            CreateMap<User, UserRequestEdit>()
               .ReverseMap();

            CreateMap<UserResponseDto, User>();

            CreateMap<BaseEntityResponse<User>, BaseEntityResponse<UserResponseDto>>()
                .ReverseMap();

            CreateMap<BaseEntityResponse<UserResponseDto>, BaseEntityResponse<User>>()
                .ReverseMap();

        }
    }
}
