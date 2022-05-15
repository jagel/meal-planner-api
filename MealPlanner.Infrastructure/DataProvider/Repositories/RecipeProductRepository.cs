using JGL.Recipes.Domain.Entities;
using JGL.Recipes.Domain.Interfaces;
using JGL.Infrastructure.DataProvider.Context;

namespace JGL.Recipes.Infrastructure.DataProvider.Repositories
{
    public class RecipeProductRepository : IRecipeProductRepository
    {
        private readonly DbMealPlannerContext _context;

        public RecipeProductRepository(DbMealPlannerContext context)
        {
            _context = context;
        }

        public async Task<(bool,int)> DeleteByRecipeIdAsync(int RecipeId)
        {
            var recipeProducts = _context.Set<RecipeProduct>().Where(x => x.RecipeId == RecipeId);

            _context.Set<RecipeProduct>().RemoveRange(recipeProducts);

            var recipeProductsRemoved = await _context.SaveChangesAsync();

            return (true, recipeProductsRemoved);
        }
    }
}
