using System.ComponentModel.DataAnnotations;

namespace JGL.Security.Auth.Data.Requests
{
    /// <summary>
    /// Recipe returns recipe model.
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// email
        /// </summary>
        /// <example>
        /// mail@examplle.com
        /// </example>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        /// <example>
        /// jagel
        /// </example>
        [Required]
        public string Username { get; set; }


        /// <summary>
        /// Name
        /// </summary>
        /// <example>
        /// Javier
        /// </example>
        [Required]
        public string Name { get; set; }


        /// <summary>
        /// Lastname
        /// </summary>
        /// <example>
        /// Garcia
        /// </example>
        [Required]
        public string Lastname { get; set; }


        /// <summary>
        /// Password
        /// </summary>
        /// <example>
        /// 12345678
        /// </example>
        [Required]
        public string Password { get; set; }
    }
}
