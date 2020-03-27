using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private SaveCategoryResponse(bool success, string message, Category category)
             : base(success, message)
        {
            Category = category;
        }

        
        /// <summary>
        /// Create a success response
        /// </summary>
        /// <param name = "category"> Saved Category </param>
        /// <return> Response </return>
        public SaveCategoryResponse(Category category) : this(true, string.Empty, category)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveCategoryResponse(string message) : this(false, message, null)
        {
        }

    }
}