using MealPlanner.Data.Globals.Exceptions;

namespace MealPlanner.Api.Middelwares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Call the next delegate/middleware in the pipeline.
            try
            {
                await _next(context);
            }
            catch (AppBaseException ex)
            {
                var response = new Data.Globals.ModelResponse<string>
                {
                    Data = null,
                    ErrorResponse = ex.ErrorResponse
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }

     
    }  
}