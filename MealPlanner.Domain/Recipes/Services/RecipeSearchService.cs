using AutoMapper;
using JGL.Recipes.Contracts.Models.Recipes;
using JGL.Recipes.Domain.Interfaces;
using JGL.Domain.Entities.Recipes.Filters;

namespace JGL.Recipes.Domain.Services
{
    public class RecipeSearchService : IRecipeSearchService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeSearchService(
            IRecipeRepository recipeRepository, 
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Recipe>> SearchAsync(RecipeSearch recipeSearchParams)
        {
            var recipeFilters = _mapper.Map<RecipeFilters>(recipeSearchParams);

            var recipes = await _recipeRepository.GetByParamsAsync(recipeFilters);

            var recipeResponse = _mapper.Map<IEnumerable<Recipe>>(recipes);
            return recipeResponse;
        }
    }
}
