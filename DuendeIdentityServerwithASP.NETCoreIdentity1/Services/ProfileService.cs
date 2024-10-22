using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;

namespace DuendeIdentityServerwithASP.NETCoreIdentity1.Services;

public class ProfileService: IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context) {
        var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
        context.IssuedClaims.AddRange(roleClaims);
        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context) {
        return Task.CompletedTask;
    }
}