using AutoMapper;
using MealPlanner.Api.Models.Recipes;
using MealPlanner.Data;
using Entities = MealPlanner.Domain.Entities.Recipes;

namespace MealPlanner.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ------- Recipe
            CreateMap<Recipe, Entities.Recipes.Recipe>()
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.RecipeId))
                .ReverseMap();
        }
    }
}
