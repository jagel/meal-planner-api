using JGL.Recipes.Contracts.Models.Recipes;
using JGL.Recipes.Domain.Extensions;
using JGL.Recipes.Domain.Interfaces;
using EntitiesFilter = JGL.Recipes.Domain.Entities.Filters;

namespace JGL.Recipes.Domain.Services
{
    public class RecipeSearchService : IRecipeSearchService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeSearchService(
            IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<Recipe>> SearchAsync(RecipeSearch recipeSearchParams)
        {

            var recipeFilters = new EntitiesFilter.RecipeSearch
            {
                Name = recipeSearchParams.Name
            };

            var recipes = await _recipeRepository.GetByParamsAsync(recipeFilters);

            var recipeResponse = recipes.Select(r => new Recipe 
            { 
                Name = r.Name,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                Description = r.Description,
                RecipeId = r.Id,
                Steps = r.Steps.StepsToList(),
                UpdatedBy = r.UpdatedBy,
                UpdatedDate = r.UpdatedDate,
                RecipeProducts = r.RecipeProducts.Select(rp => new RecipeProduct
                {
                    RecipeProductId = rp.Id,
                    Fractionary = rp.Fractionary,
                    MeasureType = rp.MeasureType,
                    Name = rp.Name,
                    Quantity = rp.Quantity
                })
            });

            return recipeResponse;
        }
    }
}
