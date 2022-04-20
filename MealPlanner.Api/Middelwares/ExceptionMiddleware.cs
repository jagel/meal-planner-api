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
                ex.GenerateErrorResponse();

                var response = new JGLModelResponse<string>
                {
                    Data = null,
                    ErrorResponse = ex.ErrorResponse
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }

     
    }  
}