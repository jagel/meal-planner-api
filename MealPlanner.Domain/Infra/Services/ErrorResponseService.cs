using JGL.Data.Definitions;
using JGL.Infra.ErrorManager.Data.Definitions;
using JGL.Infra.ErrorManager.Data.Responses;
using JGL.Infra.ErrorManager.Domain.Interfaces;

namespace JGL.Infra.ErrorManager.Domain.Services
{
    public class ErrorResponseService : IErrorResponseService
    {
        public List<ErrrorItem> CreateErrorResponse(eMessageCollection messageCode)
        {
            throw new NotImplementedException();
        }

        public List<ErrrorItem> Duplicated(string fieldName, EErrorMessageSource errorSource, List<ErrrorItem>? errors = null)
        {
            throw new NotImplementedException();
        }

        public List<ErrrorItem> NotFound(string itemName)
        {
            throw new NotImplementedException();
        }

        public List<ErrrorItem> Unauthorized()
        {
            throw new NotImplementedException();
        }
    }
}
