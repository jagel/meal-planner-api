using JGL.Infra.ErrorManager.Data.Responses;
using JGL.Infra.Globals.API.Responses;

namespace JGL.Infra.ErrorManager.Domain.Exceptions
{
    public class JGLAppException : Exception
    {
        public ErrorResponse ErrorResponse { get; set; } = new ErrorResponse();
        public JGLAppException(List<ErrrorItem> errorItems) : base()
        {
            ErrorResponse.Errros = errorItems;
        }

        public JGLModelResponse<string> GenerateErrorResponse()
        {
            var criticalError = ErrorResponse.Errros.OrderBy(x => x.MessageType).FirstOrDefault();
            var title = criticalError?.Message.Split('.').FirstOrDefault() ?? "";
            ErrorResponse.Title = title;
            ErrorResponse.Description = criticalError.Message;
            ErrorResponse.MessageType = criticalError?.MessageType??Globals.Data.Definitions.EMessageDisplay.lockDisplay;

            return new JGLModelResponse<string>()
            {
                Code = criticalError.Code,
                Data = null,
                ErrorResponse = ErrorResponse
            };
        }
    }
}
