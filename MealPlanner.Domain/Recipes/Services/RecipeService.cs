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
                RecipeProducts = recipeCreate.RecipeProducts.Select(rp => new RecipesEntities.RecipeProduct
                {
                    Name = rp.Name,
                    Fractionary = rp.Fractionary,
                    MeasureType = rp.MeasureType,
                    Quantity = rp.Quantity
                })
            };
            
            var recipeCreated = await _recipeRepository.CreateAsync(createRecipeEntity);


            var recipeResponse = new Recipe
            {
                CreatedBy = recipeCreated.CreatedBy,
                CreatedDate = recipeCreated.CreatedDate,
                Description = recipeCreated.Description,
                Name = recipeCreated.Name,
                RecipeId = recipeCreated.Id,
                RecipeProducts = recipeCreated.RecipeProducts.Select(rp => new RecipeProduct
                {
                    RecipeProductId = rp.Id,
                    Name = rp.Name,
                    Fractionary = rp.Fractionary,
                    MeasureType = rp.MeasureType,
                    Quantity = rp.Quantity
                }),
                Steps = recipeCreated.Steps.StepsToList(),
                UpdatedBy = recipeCreated.UpdatedBy,
                UpdatedDate = recipeCreated.UpdatedDate
            };
            
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

            var recipeResponse = new Recipe
            {
                CreatedBy = recipe.CreatedBy,
                CreatedDate = recipe.CreatedDate,
                Description = recipe.Description,
                Name = recipe.Name,
                RecipeId = recipe.Id,
                RecipeProducts = recipe.RecipeProducts.Select(rp => new RecipeProduct
                {
                    RecipeProductId = rp.Id,
                    Name = rp.Name,
                    Fractionary = rp.Fractionary,
                    MeasureType = rp.MeasureType,
                    Quantity = rp.Quantity
                }),
                Steps = recipe.Steps.StepsToList(),
                UpdatedBy = recipe.UpdatedBy,
                UpdatedDate = recipe.UpdatedDate
            };

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
                RecipeProducts = recipeUpdate.RecipeProducts.Select(rp => new RecipesEntities.RecipeProduct
                {
                    Name = rp.Name,
                    Fractionary = rp.Fractionary,
                    MeasureType = rp.MeasureType,
                    Quantity = rp.Quantity
                }),
            };


            await _recipeProductRepository.DeleteByRecipeIdAsync(recipeUpdate.RecipeId);

            var recipeCreated = await _recipeRepository.UpdateAsync(updateRecipeEntity);

            var recipeResponse = new Recipe
            {
                CreatedBy = recipeCreated.CreatedBy,
                CreatedDate = recipeCreated.CreatedDate,
                Description = recipeCreated.Description,
                Name = recipeCreated.Name,
                RecipeId = recipeCreated.Id,
                RecipeProducts = recipeCreated.RecipeProducts.Select(rp => new RecipeProduct
                {
                    RecipeProductId = rp.Id,
                    Name = rp.Name,
                    Fractionary = rp.Fractionary,
                    MeasureType = rp.MeasureType,
                    Quantity = rp.Quantity
                }),
                Steps = recipeCreated.Steps.StepsToList(),
                UpdatedBy = recipeCreated.UpdatedBy,
                UpdatedDate = recipeCreated.UpdatedDate
            };

            return recipeResponse;
        }

    }
}
