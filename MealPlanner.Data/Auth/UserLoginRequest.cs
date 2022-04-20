using System.ComponentModel.DataAnnotations;

namespace JGL.Security.Auth.Data.Requests
{
    /// <summary>
    /// Recipe returns recipe model.
    /// </summary>
    public class UserLoginRequest
    {
        /// <summary>
        /// email
        /// </summary>
        /// <example>
        /// mail@examplle.com
        /// </example>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        /// <example>
        /// 12345678
        /// </example>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Remember account, persist user session active (optional)
        /// </summary>
        /// <example>
        /// false
        /// </example>
        public bool? RememberAccount { get; set; }
    }
}
