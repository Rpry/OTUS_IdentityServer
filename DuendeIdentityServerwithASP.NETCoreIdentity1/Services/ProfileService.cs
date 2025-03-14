using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;

namespace DuendeIdentityServerwithASP.NETCoreIdentity1.Services;

public class ProfileService: IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        if (context.Caller == "ClaimsProviderIdentityToken")
        {
            var indentityResourceClaimNames = context.RequestedResources.Resources.IdentityResources.SelectMany(r => r.UserClaims).ToList();
            var indentityResourceClaims = context.Subject.FindAll((c) => indentityResourceClaimNames.Contains(c.Type));
            context.IssuedClaims.AddRange(indentityResourceClaims);    
        }
        if (context.Caller == "ClaimsProviderAccessToken")
        {
            var apiScopeClaimNames = context.RequestedResources.Resources.ApiScopes.SelectMany(r => r.UserClaims).ToList();
            var apiScopeClaims = context.Subject.FindAll((c) => apiScopeClaimNames.Contains(c.Type));
            context.IssuedClaims.AddRange(apiScopeClaims);    
        }

        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context) {
        return Task.CompletedTask;
    }
}