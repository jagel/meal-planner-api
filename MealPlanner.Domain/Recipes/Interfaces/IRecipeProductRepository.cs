
using JGL.Recipes.Domain.Entities;

namespace JGL.Recipes.Domain.Interfaces
{
    public interface IRecipeProductRepository
    {
        public Task<(bool, int)> DeleteAsyncByRecipeId(int RecipeId);
    }
}
