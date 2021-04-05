using Blazored.LocalStorage;
using jpr.core;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
namespace JPR.WebClient
{
    public class AuthStateProvider : AuthenticationStateProvider
    {

        private readonly HttpClient Client;

        private readonly ILocalStorageService LocalStorage;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            Client = httpClient;
            LocalStorage = localStorage;
        }

        public AuthStateProvider()
        {

        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var email = await LocalStorage.GetItemAsync<string>("Email");
            var firstName = await LocalStorage.GetItemAsync<string>("FirstName");
            var lastName = await LocalStorage.GetItemAsync<string>("LastName");


            if (email != null && firstName != null && lastName != null)
            {
                var EmailAddress = new Claim(ClaimTypes.Name, email);
                var claimNameGivenName = new Claim(ClaimTypes.GivenName, firstName);
                var claimNameSurname = new Claim(ClaimTypes.Surname, lastName);
                var claimsIdentity = new ClaimsIdentity(new[] { EmailAddress, claimNameGivenName, claimNameSurname }, "Auth");

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);

            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }


        }

        public async Task MarkUserAsLoggedIn(UserProfileDetailsApiModel user)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),

            }, "serverauth");

            var claimsPrincipal = new ClaimsPrincipal(identity);

            await LocalStorage.SetItemAsync("Email", user.Email);
            await LocalStorage.SetItemAsync("Token", user.Token);

            await LocalStorage.SetItemAsync("FirstName", user.FirstName);
            await LocalStorage.SetItemAsync("LastName", user.LastName);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            var identity = new ClaimsIdentity();

            var claimsPrincipal = new ClaimsPrincipal(identity);

            await LocalStorage.RemoveItemAsync("Email");
            await LocalStorage.RemoveItemAsync("Token");
            await LocalStorage.RemoveItemAsync("firstName");
            await LocalStorage.RemoveItemAsync("lastName");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetTokenAsync()
        {
            var token = await LocalStorage.GetItemAsync<string>("Token");
            return token;
        }


    }
}
