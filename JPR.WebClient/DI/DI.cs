using Dna;
using Microsoft.Extensions.DependencyInjection;
namespace JPR.WebClient
{
    /// <summary>
    /// A shorthand access class to get DI services with nice clean short code
    /// </summary>
    public static class DI
    {
        /// <summary>
        /// The scoped instance of the <see cref="AuthStateProvider"/>
        /// </summary>
        public static AuthStateProvider AuthState => Framework.Provider.GetRequiredService<AuthStateProvider>();

        /// <summary>
        /// The transient instance of the <see cref="IUserService"/>
        /// </summary>
        public static IUserService SMSSender => Framework.Provider.GetRequiredService<IUserService>();
    }
}
