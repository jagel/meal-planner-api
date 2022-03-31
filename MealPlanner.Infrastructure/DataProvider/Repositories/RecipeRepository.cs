using JGL.Recipes.Domain.Entities;
using JGL.Recipes.Domain.Interfaces;
using MealPlanner.Infrastructure.DataProvider.Context;
using Microsoft.EntityFrameworkCore;

namespace JGL.Recipes.Infrastructure.DataProvider.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DbMealPlannerContext _context;

        public RecipeRepository(DbMealPlannerContext context)
        {
            _context = context;
        }
        
        public async Task<Recipe> Create(Recipe recipeCreate)
        {
            _context.Set<Recipe>().Add(recipeCreate);
            
            var savedCount  = await _context.SaveChangesAsync();

            return recipeCreate;
        }

        public async Task<bool> Delete(Recipe recipeRemove)
        {
            _context.Set<Recipe>().Remove(recipeRemove);
            var removedCount = await _context.SaveChangesAsync();

            return removedCount>0;
        }

        public async Task<Recipe> GetById(int RecipeId)
        {
            var recipe = await _context.Set<Recipe>()
                .Where(x => x.Id == RecipeId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return recipe;
        }

        public async Task<Recipe> Update(Recipe recipeUpdate)
        {
            _context.Set<Recipe>().Update(recipeUpdate);

            var updatedCount = await _context.SaveChangesAsync();

            return recipeUpdate;
        }
    }
}
