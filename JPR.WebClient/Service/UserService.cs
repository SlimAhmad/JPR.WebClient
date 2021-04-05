using jpr.core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JPR.WebClient
{
    public class UserService : IUserService
    {

        public HttpClient Client { get; }

        public UserService(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:5030/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "jpr.server");

            Client = httpClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApiResponse<UserProfileDetailsApiModel>> LoginAsync(LoginCredentialsApiModel user)
        {
            WebRequest webRequest = new WebRequest(Client);

            var result = await webRequest.GetApiResponseAsync<ApiResponse<UserProfileDetailsApiModel>>(
                 ApplicationMediaType.Json,
                 ApiRoutes.Login,
                 new LoginCredentialsApiModel { UsernameOrEmail = user.UsernameOrEmail, Password = user.Password }
                 );


            // await AuthState.MarkUserAsLoggedIn(result.Response);
            return new ApiResponse<UserProfileDetailsApiModel>
            {
                Response = new UserProfileDetailsApiModel
                {
                    Email = result.Response.Email,
                    FirstName = result.Response.FirstName,
                    LastName = result.Response.LastName,
                    Role = result.Response.Role,
                    Token = result.Response.Token,
                    Username = result.Response.Username
                }

            };

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<List<RegisterCredentialsApiModel>> GetUsers(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var users = await webRequest.GetApiResponseAsync<ApiResponse<UsersResultsApiModel>>(
                 ApplicationMediaType.Json,
                 UserApiRoutes.Users,
                 null,
                 token
                 );

            var results = new List<RegisterCredentialsApiModel>();
            foreach (var user in users.Response)
            {
                results.Add(new RegisterCredentialsApiModel
                {
                    Username = user.Username,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role[0],
                    Id = user.Id,
                    ProfileImage = user.ProfileImage

                });
            }

            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteUser(string token, RegisterCredentialsApiModel model)
        {
            var role = new List<string>();
            role.Add(model.Role);
            var user = new UpdateUserProfileApiModel()
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = model.Id,
                Username = model.Username,
                Role = role,

            };
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 UserApiRoutes.Delete,
                 user,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = response.ErrorMessage };

            return new ApiResponse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UpdateUser(string token, RegisterCredentialsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);


            var role = new List<string>();
            role.Add(model.Role);
            var user = new UpdateUserProfileApiModel()
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = model.Id,
                Username = model.Username,
                Role = role,

            };
            var response = await webRequest.GetApiResponseAsync<ApiResponse>(
                 ApplicationMediaType.Json,
                 UserApiRoutes.Update,
                 user,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = response.ErrorMessage };

            return new ApiResponse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> RegisterUser(string token, RegisterCredentialsApiModel model)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse<RegisterCredentialsApiModel>>(
                 ApplicationMediaType.Json,
                 UserApiRoutes.Register,
                 model,
                 token
                 );
            if (!response.Successful)
                // Return failed Response
                return new ApiResponse() { ErrorMessage = response.ErrorMessage };

            return new ApiResponse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<UsersResultsApiModel> GetAdminUsers(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse<UsersResultsApiModel>>(
                 ApplicationMediaType.Json,
                 UserApiRoutes.Register,
                 null,
                 token
                 );
            var results = new UsersResultsApiModel();

            results.AddRange(response.Response);

            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<UsersResultsApiModel> GetAgentUsers(string token)
        {
            WebRequest webRequest = new WebRequest(Client);

            var response = await webRequest.GetApiResponseAsync<ApiResponse<UsersResultsApiModel>>(
                 ApplicationMediaType.Json,
                 UserApiRoutes.Register,
                 null,
                 token
                 );

            var results = new UsersResultsApiModel();

            results.AddRange(response.Response);

            return results;
        }
    }
}
