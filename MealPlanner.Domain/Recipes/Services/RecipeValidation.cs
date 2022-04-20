using JGL.Recipes.Domain.Entities;
using JGL.Recipes.Domain.Interfaces;
using JGL.Infra.ErrorManager.Domain.Interfaces;
using JGL.Infra.ErrorManager.Domain.Exceptions;

namespace JGL.Recipes.Domain.Validations
{
    public class RecipeValidation : IRecipeValidation
    {
        private readonly IErrorResponseService _errorResponseService;

        public RecipeValidation(IErrorResponseService errorResponseService)
        {
            _errorResponseService = errorResponseService;
        }

        public void RecipeNotNullValidation(Recipe recipe)
        {
            if (recipe == null)
            {
                var errors = _errorResponseService.NotFound("Recipe");
                throw new JGLAppException(errors);
            }
        }
    }
}
