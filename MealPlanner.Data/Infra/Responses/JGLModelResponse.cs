using JGL.Infra.ErrorManager.Data.Definitions;
using JGL.Infra.ErrorManager.Data.Responses;

namespace JGL.Infra.Globals.API.Responses
{
    /// <summary>
    /// Global Model Response.
    /// </summary>
    public class JGLModelResponse<TModelResponse>
    {
        /// <summary>
        /// Validates model response has errors
        /// </summary>
        /// <example>
        /// false
        /// </example>
        public bool HasErrors { get { return Data == null; } }

        /// <summary>
        /// Code response
        /// </summary>
        /// <example>
        /// 200
        /// </example>
        public Int16 Code { get; set; } = ApiCodesResponse.Success;

        /// <summary>
        /// Catch error information in case the request could did not finished
        /// </summary>
        /// <example>
        /// 
        /// </example>
        public ErrorResponse? ErrorResponse { get; set; }

        /// <summary>
        /// Model Response
        /// </summary>
        /// <example>
        /// 
        /// </example>
        public TModelResponse? Data { get; set; }
    }
}