using JGL.Recipes.Domain.Entities;
using JGL.Recipes.Domain.Interfaces;
using JGL.Recipes.Domain.Entities.Filters;
using JGL.Infrastructure.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace JGL.Recipes.Infrastructure.DataProvider.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DbMealPlannerContext _context;

        public RecipeRepository(DbMealPlannerContext context)
        {
            _context = context;
        }
        
        public async Task<Recipe> CreateAsync(Recipe recipeCreate)
        {
            _context.Set<Recipe>().Add(recipeCreate);
            
            var savedCount  = await _context.SaveChangesAsync();

            return recipeCreate;
        }

        public async Task<bool> DeleteAsync(Recipe recipeRemove)
        {
            _context.Set<Recipe>().Remove(recipeRemove);
            var removedCount = await _context.SaveChangesAsync();

            return removedCount>0;
        }

        public async Task<Recipe> GetByIdAsync(int RecipeId, RecipeFilter recipeFilters = null)
        {
            Recipe? recipe = null;
           
            if (recipeFilters?.IncludeProducts == true)
            {
                recipe = await _context.Set<Recipe>()
                    .Where(x => x.Id == RecipeId)
                    .Include(x=>x.RecipeProducts)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            else
            {
                recipe = await _context.Set<Recipe>()
                   .Where(x => x.Id == RecipeId)
                   .AsNoTracking()
                   .FirstOrDefaultAsync();
            }
       

            return recipe??new Recipe();
        }

        public async Task<IEnumerable<Recipe>> GetByParamsAsync(RecipeSearch recipeFilters)
        {
            var query = from u in _context.Set<Recipe>() select u;
            //var predicate = PredicateBuilder.False<Recipe>();

            //var recipeQuery = _context.Set<Recipe>();
            //predicate?.And(x => x.Name == recipeFilters.Name);

            var recipes = await query.Where(x => x.Name.Contains(recipeFilters.Name)).ToListAsync();
            return recipes;
        }

        public async Task<Recipe> UpdateAsync(Recipe recipeUpdate)
        {
            _context.Set<Recipe>().Update(recipeUpdate);

            var updatedCount = await _context.SaveChangesAsync();

            var recipeUpdated = await GetByIdAsync(recipeUpdate.Id);

            return recipeUpdated;
        }
    }
}
