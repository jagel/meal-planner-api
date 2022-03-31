using AutoMapper;
using MealPlanner.Api.Models.Recipes;
using MealPlanner.Domain.Recipes.Interfaces;
using RecipesEntities = MealPlanner.Domain.Entities.Recipes;
namespace MealPlanner.Domain.Recipes.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly IRecipeValidation _recipeValidation;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper, IRecipeValidation recipeValidation)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
            _recipeValidation = recipeValidation;
        }

        public async Task<Recipe> Create(RecipeCreate recipeCreate)
        {
            var createRecipeEntity = _mapper.Map<RecipesEntities.Recipe>(recipeCreate);
            var recipeCreated = await _recipeRepository.Create(createRecipeEntity);

            var recipeResponse = _mapper.Map<Recipe>(recipeCreated);
            return recipeResponse;
        }

        public async Task<bool> Delete(int recipeId)
        {
            var recipe = await _recipeRepository.GetById(recipeId);

            _recipeValidation.RecipeNotNullValidation(recipe);

            var recipeDeleted = await _recipeRepository.Delete(recipe);
            return recipeDeleted;
        }

        public async Task<Recipe> GetById(int recipeId)
        {
            var recipe = await _recipeRepository.GetById(recipeId);
            
            _recipeValidation.RecipeNotNullValidation(recipe);

            var recipeResponse = _mapper.Map<Recipe>(recipe);
            return recipeResponse;
        }

        public async Task<Recipe> Update(RecipeUpdate recipeUpdate)
        {
            var updateRecipeEntity = _mapper.Map<RecipesEntities.Recipe>(recipeUpdate);
            var recipeCreated = await _recipeRepository.Update(updateRecipeEntity);

            var recipeResponse = _mapper.Map<Recipe>(recipeCreated);
            return recipeResponse;
        }
    }
}
