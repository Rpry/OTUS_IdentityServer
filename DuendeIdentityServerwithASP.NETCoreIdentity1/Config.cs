using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace DuendeIdentityServerwithASP.NETCoreIdentity1;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("api1") 
        };
    
    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "integration_test",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "api1" }
            },

            // interactive client using code flow + pkce
            // JavaScript Client
            new Client
            {
                ClientId = "js",
                ClientName = "JavaScript Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                AllowOfflineAccess = true,
                RedirectUris =           { "https://localhost:4200" },
                PostLogoutRedirectUris = { "https://localhost:4200" },
                AllowedCorsOrigins =     { "https://localhost:4200" },
                AccessTokenLifetime = 65,
                IdentityTokenLifetime = 65,
                RequirePkce = true,
                RequireConsent = true,
                AllowedScopes = 
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "api1",
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                }
            }
        };
}