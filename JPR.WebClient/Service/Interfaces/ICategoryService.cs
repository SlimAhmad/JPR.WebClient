using jpr.core;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public interface ICategoryService
    {

        /// <summary>
        /// Tries to get all categories on the server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<CategoryResultsApiModel> GetCategoriesAsync(string token);

        /// <summary>
        /// Tries to add a category on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">The category details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> AddCategoryAsync(string token, CategoryApiModel model);


        /// <summary>
        /// Tries to update a category on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the category details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> UpdateCategoryAsync(string token, CategoryApiModel model);

        /// <summary>
        /// Tries to delete a category on to server
        /// </summary>
        /// <param name="token">The users token</param>
        /// <param name="model">the category details</param>
        /// <returns>Returns the result of a successful request</returns>
        Task<ApiResponse> DeleteCategoryAsync(string token, CategoryApiModel model);




    }
}
