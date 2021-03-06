using AutoMapper;
using JGL.Recipes.Contracts.Models.Recipes;
using JGL.Recipes.Domain.Extensions;
using JGL.Domain.Entities.Recipes.Filters;
using RecipeEntities = JGL.Recipes.Domain.Entities;

namespace JGL.Recipes.Domain.Mapper
{
    public class RecipeMappingProfile : Profile
    {
        public RecipeMappingProfile()
        {
            CreateMap<RecipeEntities.Recipe, Recipe>()
                .ForMember(dest => dest.RecipeId, from => from.MapFrom(src => src.Id))
                .ForMember(dest => dest.Steps, from => from.MapFrom(src => src.Steps.StepsToList()))
                .ReverseMap();

            CreateMap<RecipeCreate, RecipeEntities.Recipe>()
                .ForMember(dest => dest.Steps, from => from.MapFrom(src => src.Steps.StepsToString()))
                .ReverseMap();

            CreateMap<RecipeUpdate, RecipeEntities.Recipe>()
                .ForMember(dest => dest.Id, from => from.MapFrom(src => src.RecipeId))
                .ForMember(dest => dest.Steps, from => from.MapFrom(src => src.Steps.StepsToString()))
                .ReverseMap();

            CreateMap<RecipeEntities.RecipeProduct, RecipeProduct>()
              .ForMember(dest => dest.RecipeProductId, from => from.MapFrom(src => src.Id))
              .ReverseMap();

            CreateMap<RecipeProductCreate, RecipeProduct>()
             .ReverseMap();

            CreateMap<RecipeSearch, RecipeFilters>()
                .ReverseMap();

        }
    }
}
