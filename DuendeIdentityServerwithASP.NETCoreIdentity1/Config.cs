﻿using Duende.IdentityServer;
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
            new IdentityResource()
            {
                Name = "employee_info",
                DisplayName = "Employee information",
                Description = "Employee information including seniority and status...",
                UserClaims = new List<string>
                {
                    "employment_start",
                    "seniority",
                    "contractor",
                    "api1"
                }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope()
            {
                Name = "myscope",
                DisplayName = "myscope",
                Description = "myscope",
                UserClaims = new List<string>
                {
                    "api1"
                },
            },
            new ApiScope("myscope2")
            {
                UserClaims = new List<string>()
                {
                    "website"
                },
                Required = true,
                Name = "myscope2",
                DisplayName = "myscope2"
            },
            new ApiScope()
            {
                Name = "role",
                DisplayName = "role",
                Description = "role",
                UserClaims = new List<string>
                {
                    "role"
                },
            },
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
                RedirectUris =           { "http://localhost:4200"},//, "http://localhost:4200/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:4200"},//, "http://localhost:4200/signout-oidc" },
                AllowedCorsOrigins =     { "http://localhost:4200" },
                AccessTokenLifetime = 5,
                IdentityTokenLifetime = 65,
                RequirePkce = true,
                RequireConsent = true,
                AlwaysIncludeUserClaimsInIdToken  = true,
                AlwaysSendClientClaims = true,
                AllowedScopes = 
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "myscope",
                    IdentityServerConstants.StandardScopes.OfflineAccess,
                    "role"
                }
            }
        };
}