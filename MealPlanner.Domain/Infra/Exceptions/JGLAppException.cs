using JGL.Infra.ErrorManager.Data.Responses;

namespace JGL.Infra.ErrorManager.Domain.Exceptions
{
    public class JGLAppException : Exception
    {
        public ErrorResponse ErrorResponse { get; set; }

        public JGLAppException(List<ErrrorItem> errorItems):base()
        {
            ErrorResponse = new ErrorResponse
            {
                Errros = errorItems
            };
        }

        public void GenerateErrorResponse()
        {

        }
    }
}
