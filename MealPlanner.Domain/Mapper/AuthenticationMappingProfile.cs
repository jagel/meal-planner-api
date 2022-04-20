using AutoMapper;
using JGL.Security.Auth.Domain.Entities;
using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Data.Responses;

namespace JGL.Security.Auth.Domain.Mapper
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<CreateUserRequest, User>()
              .ReverseMap();

            CreateMap<UserResponse, User>()
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.UserId))
                .ReverseMap();

            CreateMap<User, UserSessionResponse>()
                .ForMember(dest => dest.DisplayName, from => from.MapFrom(src => src.Username))
                .ReverseMap();

            
        }

    }
}
