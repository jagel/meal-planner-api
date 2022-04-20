using JGL.Data.Definitions;
using JGL.Infra.ErrorManager.Data.Definitions;
using JGL.Infra.ErrorManager.Data.Responses;

namespace JGL.Infra.ErrorManager.Domain.Interfaces
{
    public interface IErrorResponseService
    {
        List<ErrrorItem> Duplicated(string fieldName, EErrorMessageSource errorSource, List<ErrrorItem>? errors = null);
        List<ErrrorItem> NotFound(string itemName);
        List<ErrrorItem> CreateErrorResponse(eMessageCollection messageCode);
        List<ErrrorItem> Unauthorized();
    }
}
