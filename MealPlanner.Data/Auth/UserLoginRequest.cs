using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Data.Auth
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
    }
}
