using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Data.Auth
{
    /// <summary>
    /// Recipe returns recipe model.
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// UserId
        /// </summary>
        /// <example>
        /// 1
        /// </example>
        [Required]
        public int UserId { get; set; }

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


    }
}
