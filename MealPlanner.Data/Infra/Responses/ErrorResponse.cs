using JGL.Infra.Globals.Data.Definitions;

namespace JGL.Infra.ErrorManager.Data.Responses
{
    /// <summary>
    /// Global model Response
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Error response title
        /// </summary>
        /// <example>
        /// Invalid Request
        /// </example>
        public string Title { get; set; }

        /// <summary>
        /// Error Description
        /// </summary>
        /// <example>
        /// Name is required
        /// </example>
        public string Description { get; set; }

        /// <summary>
        /// Message type
        /// </summary>
        /// <example>
        /// 1
        /// </example>
        public EMessageDisplay MessageType { get; set; }

        /// <summary>
        /// Error collection items
        /// </summary>
        public List<ErrrorItem> Errros { get; set; }
    }
    
   
}
