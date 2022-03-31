using AutoMapper;
using MealPlanner.Data.Auth;
using MealPlanner.Domain.Entities.Auth;

namespace MealPlanner.Domain.Mapper
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
        }

    }
}
