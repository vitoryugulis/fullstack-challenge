using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using IdentityServer.Interfaces;

namespace IdentityServer.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public async Task<TokenResponse> GetAccessToken(string clientId, string clientSecret, string scope)
        {
            try
            {
                var client = new HttpClient();
                var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5002");
                if (disco.IsError)
                {
                    Console.WriteLine(disco.Error);
                    throw new Exception(disco.Error);
                }
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Scope = scope
                });

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                    throw new Exception(tokenResponse.Error);
                }

                Console.WriteLine(tokenResponse.Json);
                return tokenResponse;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }


        }
    }
}