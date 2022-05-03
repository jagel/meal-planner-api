using JGL.Infra.ErrorManager.Data.Responses;
using JGL.Infra.ErrorManager.Domain.Interfaces;
using JGL.Infra.Globals.API.Definitions;
using JGL.Infra.Globals.API.Domain.Interfaces;
using System.Reflection;

namespace JGL.Infra.ErrorManager.Domain.Services
{
    public class ErrorResponseService : IErrorResponseService
    {
        private readonly IUserSessionProfile _userSessionProfile;

        public ErrorResponseService(IUserSessionProfile userSessionProfile)
        {
            _userSessionProfile = userSessionProfile;
        }

        public List<ErrrorItem> Duplicated<TValueDuplicated>(string duplicatedArea, string fieldName, TValueDuplicated value, List<ErrrorItem>? errors = null)
        {
            errors = errors ?? new List<ErrrorItem>();

            var duplicatedError = new ErrrorItem
            {
                Code = CodeResponse.DUPLICATED,
                Domain = Assembly.GetExecutingAssembly().GetName().Name ?? "",
                Message = String.Format(CodeResponse.DUPLICATED_MESSAGE, duplicatedArea, fieldName, value),
                MessageType = Globals.Data.Definitions.EMessageDisplay.alert
            };

            errors.Add(duplicatedError);

            return errors;
        }

        public List<ErrrorItem> NotFound(string itemName, List<ErrrorItem>? errors = null)
        {
            errors = errors ?? new List<ErrrorItem>();

            var notFoundError = new ErrrorItem
            {
                Code = CodeResponse.NOTFOUND,
                Domain = Assembly.GetExecutingAssembly().GetName().Name ?? "",
                Message = String.Format(CodeResponse.NOTFOUND_MESSAGE, itemName),
                MessageType = Globals.Data.Definitions.EMessageDisplay.alert
            };
            errors.Add(notFoundError);

            return errors;
        }

        public List<ErrrorItem> Unauthorized() =>
            new()
            {
                new ErrrorItem
                {
                    Code = CodeResponse.UNAUTHORIZED,
                    Domain = Assembly.GetExecutingAssembly().GetName().Name ?? "",
                    Message = CodeResponse.UNAUTHORIZED_MESSAGE,
                    MessageType = Globals.Data.Definitions.EMessageDisplay.lockDisplay
                }
            };
    }
}
