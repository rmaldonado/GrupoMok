using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApiAuthorizacion.Helpers
{
    public class Header
    {
        public static async Task<string> GetToken(IHeaderDictionary headers)
        {
            headers.TryGetValue("Authorization", out var headerValue);
            return await Task.Run(() => headerValue);
        }
    }
}
