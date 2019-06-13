namespace IdentityServer.Models
{
    public class AccessTokenBindingModel
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
    }
}