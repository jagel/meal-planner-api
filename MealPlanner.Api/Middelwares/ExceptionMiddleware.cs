using JGL.Infra.ErrorManager.Domain.Exceptions;

namespace JGL.Api.Middelwares
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
            catch (JGLAppException ex)
            {
                var response = ex.GenerateErrorResponse();
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                var response = new JGLModelResponse<string>
                {
                    Data = null,
                    ErrorResponse = new Infra.ErrorManager.Data.Responses.ErrorResponse 
                    {
                        Title = "Unhandled error",
                        Description = ex.Message,
                    }
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }

     
    }  
}