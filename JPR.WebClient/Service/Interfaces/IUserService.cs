using jpr.core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public interface IUserService
    {
        Task<ApiResponse<UserProfileDetailsApiModel>> LoginAsync(LoginCredentialsApiModel user);

        Task<List<RegisterCredentialsApiModel>> GetUsers(string token);
        Task<ApiResponse> RegisterUser(string token, RegisterCredentialsApiModel model);
        Task<ApiResponse> UpdateUser(string token, RegisterCredentialsApiModel model);
        Task<ApiResponse> DeleteUser(string token, RegisterCredentialsApiModel model);
    }
}
