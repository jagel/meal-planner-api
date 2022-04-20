using JGL.Infra.ErrorManager.Data.Definitions;

namespace JGL.Infra.ErrorManager.Data.Responses
{
    /// <summary>
    /// Error item detail
    /// </summary>
    public class ErrrorItem
    {
        /// <summary>
        /// Error code
        /// </summary>
        /// <example>
        /// 401
        /// </example>
        public string Code { get; set; }

        /// <summary>
        /// Message type
        /// </summary>
        /// <example>
        /// JGL.Infra.ErrorManager.API
        /// </example>
        public string Domain { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        /// <example>
        /// Field is required
        /// </example>
        public string Message { get; set; }

        /// <summary>
        /// Message type
        /// </summary>
        /// <example>
        /// 1
        /// </example>
        public EErrorMessageSource MessageType { get; set; }
    }
}
