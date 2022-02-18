using AutoMapper;
using MealPlanner.Api.Models.Recipes;
using RecipeEntities = MealPlanner.Domain.Entities.Recipes;

namespace MealPlanner.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            RecipeMappingProfile();
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
