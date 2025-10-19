using JGL.Recipes.Contracts.Models.Recipes;
using JGL.Recipes.Domain.Entities.Filters;
using JGL.Recipes.Domain.Extensions;
using JGL.Recipes.Domain.Interfaces;
using RecipesEntities = JGL.Recipes.Domain.Entities;

namespace JGL.Recipes.Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeValidation _recipeValidation;
        private readonly IRecipeProductRepository _recipeProductRepository;

        public RecipeService(
            IRecipeRepository recipeRepository,
            IRecipeValidation recipeValidation,
            IRecipeProductRepository recipeProductRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeValidation = recipeValidation;
            _recipeProductRepository = recipeProductRepository;
        }

        public async Task<Recipe> Create(RecipeCreate recipeCreate)
        {

            var createRecipeEntity = new RecipesEntities.Recipe
            {
                Name = recipeCreate.Name,
                Description = recipeCreate.Description,
                Steps = recipeCreate.Steps.StepsToString(),
                RecipeProducts = [..
                    recipeCreate.RecipeProducts.Select(rp => new RecipesEntities.RecipeProduct
                    {
                        Name = rp.Name,
                        Fractionary = rp.Fractionary,
                        MeasureType = rp.MeasureType,
                        Quantity = rp.Quantity
                    })
                ]
            };

            var recipeCreated = await _recipeRepository.CreateAsync(createRecipeEntity);

            var recipeResponse = RecipeResponse(recipeCreated);

            return recipeResponse;
        }

        public async Task<bool> Delete(int recipeId)
        {
            var recipe = await _recipeRepository.GetByIdAsync(recipeId);

            _recipeValidation.RecipeNotNullValidation(recipe);

            var recipeDeleted = await _recipeRepository.DeleteAsync(recipe);
            return recipeDeleted;
        }

        public async Task<Recipe> GetById(int recipeId, RecipeFilters recipeFilters)
        {
            var filters = new RecipeFilter
            {
                IncludeProducts = recipeFilters.IncludeProducts
            };

            var recipe = await _recipeRepository.GetByIdAsync(recipeId, filters);

            _recipeValidation.RecipeNotNullValidation(recipe);

            var recipeResponse = RecipeResponse(recipe);

            return recipeResponse;
        }

        public async Task<Recipe> Update(RecipeUpdate recipeUpdate)
        {
            var updateRecipeEntity = new RecipesEntities.Recipe
            {
                Id = recipeUpdate.RecipeId,
                Name = recipeUpdate.Name,
                Description = recipeUpdate.Description,
                Steps = recipeUpdate.Steps.StepsToString(),
                RecipeProducts = [.. recipeUpdate.RecipeProducts.Select(rp => new RecipesEntities.RecipeProduct
                {
                    Name = rp.Name,
                    Fractionary = rp.Fractionary,
                    MeasureType = rp.MeasureType,
                    Quantity = rp.Quantity
                })],
            };


            await _recipeProductRepository.DeleteByRecipeIdAsync(recipeUpdate.RecipeId);

            var recipeCreated = await _recipeRepository.UpdateAsync(updateRecipeEntity);

            var recipeResponse = RecipeResponse(recipeCreated);

            return recipeResponse;
        }

        private static Recipe RecipeResponse(RecipesEntities.Recipe recipe) => new()
        {
            RecipeId = recipe.Id,
            Name = recipe.Name,
            Description = recipe.Description,
            RecipeProducts = recipe.RecipeProducts.Select(RecipeProductResponse),
            Steps = recipe.Steps.StepsToList(),
            CreatedBy = recipe.CreatedBy,
            CreatedDate = recipe.CreatedDate,
            UpdatedBy = recipe.UpdatedBy,
            UpdatedDate = recipe.UpdatedDate
        };

        private static RecipeProduct RecipeProductResponse(RecipesEntities.RecipeProduct rp) => new()
        {
            RecipeProductId = rp.Id,
            Name = rp.Name,
            Fractionary = rp.Fractionary,
            MeasureType = rp.MeasureType,
            Quantity = rp.Quantity
        };

       
    }

}
