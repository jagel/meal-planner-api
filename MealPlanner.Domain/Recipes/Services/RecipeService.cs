using AutoMapper;
using JGL.Recipes.Contracts.Models.Recipes;
using RecipesEntities = JGL.Recipes.Domain.Entities;
using JGL.Recipes.Domain.Extensions;
using JGL.Recipes.Domain.Interfaces;

namespace JGL.Recipes.Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly IRecipeValidation _recipeValidation;

        public RecipeService(
            IRecipeRepository recipeRepository, 
            IMapper mapper, 
            IRecipeValidation recipeValidation)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _recipeValidation = recipeValidation;
        }

        public async Task<Recipe> Create(RecipeCreate recipeCreate)
        {
            var createRecipeEntity = _mapper.Map<RecipesEntities.Recipe>(recipeCreate);

            createRecipeEntity.Steps = recipeCreate.Steps.StepsToString();
            var recipeCreated = await _recipeRepository.CreateAsync(createRecipeEntity);

            var recipeResponse = _mapper.Map<Recipe>(recipeCreated);
            return recipeResponse;
        }

        public async Task<bool> Delete(int recipeId)
        {
            var recipe = await _recipeRepository.GetByIdAsync(recipeId);

            _recipeValidation.RecipeNotNullValidation(recipe);

            var recipeDeleted = await _recipeRepository.DeleteAsync(recipe);
            return recipeDeleted;
        }

        public async Task<Recipe> GetById(int recipeId)
        {
            var recipe = await _recipeRepository.GetByIdAsync(recipeId);
            
            _recipeValidation.RecipeNotNullValidation(recipe);

            var recipeResponse = _mapper.Map<Recipe>(recipe);
            return recipeResponse;
        }

        public async Task<Recipe> Update(RecipeUpdate recipeUpdate)
        {
            var updateRecipeEntity = _mapper.Map<RecipesEntities.Recipe>(recipeUpdate);
            updateRecipeEntity.Steps = recipeUpdate.Steps.StepsToString();

            var recipeCreated = await _recipeRepository.UpdateAsync(updateRecipeEntity);

            var recipeResponse = _mapper.Map<Recipe>(recipeCreated);
            return recipeResponse;
        }

    }
}
