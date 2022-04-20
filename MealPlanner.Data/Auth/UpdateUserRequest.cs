using System.ComponentModel.DataAnnotations;

namespace JGL.Security.Auth.Data.Requests
{
    /// <summary>
    /// Recipe returns recipe model.
    /// </summary>
    public class UpdateUserRequest
    {
       
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

    }
}
