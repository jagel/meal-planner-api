using JGL.Infra.ErrorManager.Data.Responses;

namespace JGL.Infra.ErrorManager.Domain.Interfaces
{
    public interface IErrorResponseService
    {
        List<ErrrorItem> Duplicated<TValueDuplicated>(string duplicatedArea, string fieldName, TValueDuplicated valueDuplicated, List<ErrrorItem>? errors = null);
        List<ErrrorItem> NotFound(string itemName, List<ErrrorItem>? errors = null);
        List<ErrrorItem> Unauthorized();
    }
}
