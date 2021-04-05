using jpr.core;
using System.Diagnostics;

namespace JPR.WebClient
{
    public static class MediaTypeHelper
    {
        /// <summary>
        /// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/> that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string ToMediaTypes(this ApplicationMediaType page)
        {
            // Find the appropriate page
            switch (page)
            {
                case ApplicationMediaType.Json:
                    return "application/json";


                case ApplicationMediaType.MultipartFormData:
                    return "multipart/form-data";

                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
