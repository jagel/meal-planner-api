namespace MealPlanner.Data.Globals
{
    /// <summary>
    /// Global Model Response.
    /// </summary>
    public class ModelResponse<TModelResponse>
    {
        /// <summary>
        /// Validates model response has errors
        /// </summary>
        /// <example>
        /// false
        /// </example>
        public bool HasErrors { get { return Data == null; } }

        /// <summary>
        /// Gives aditional information about request
        /// </summary>
        /// <example>
        /// 
        /// </example>
        public ModelErrorResponse? ErrorResponse { get; set; }

        /// <summary>
        /// Model Response
        /// </summary>
        /// <example>
        /// 
        /// </example>
        public TModelResponse? Data { get; set; }
    }
}