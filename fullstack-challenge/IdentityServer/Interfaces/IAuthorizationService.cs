using System.Threading.Tasks;
using IdentityModel.Client;

namespace IdentityServer.Interfaces
{
    public interface IAuthorizationService
    {
        Task<TokenResponse> GetAccessToken(string clientId, string clientSecret, string scope);
    }
}