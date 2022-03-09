using AutoMapper;
using MealPlanner.Api.Models.Recipes;
using MealPlanner.Data.Auth;
using MealPlanner.Domain.Entities.Auth;
using RecipeEntities = MealPlanner.Domain.Entities.Recipes;

namespace MealPlanner.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AuthMappingProfile();
            RecipeMappingProfile();
        }

        private void AuthMappingProfile()
        {
            CreateMap<CreateUserRequest, User>()
                .ReverseMap();

            CreateMap<UserResponse, User>()
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.UserId))
                .ReverseMap();
        }

        private void RecipeMappingProfile()
        {
            CreateMap<Recipe, RecipeEntities.Recipe>()
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.RecipeId))
                .ReverseMap();

            CreateMap<RecipeCreate, RecipeEntities.Recipe>()
                .ReverseMap();

            CreateMap<RecipeUpdate, RecipeEntities.Recipe>()
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.RecipeId))
                .ReverseMap();
        }
    }
}
