using FacadeAndProxyDesignPattern.Common.Domain.Entities;
using FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;
using FacadeAndProxyDesignPattern.Common.Interfaces.Services;

namespace FacadeAndProxyDesignPattern.Implementation.Services;

public class UserDataService : IUserDataService
{
    private readonly ILogger _logger;
    private readonly IUserApiProxy _userApiProxy;

    public UserDataService(ILogger logger, IUserApiProxy userApiProxy)
    {
        _logger = logger;
        _userApiProxy = userApiProxy;
    }
    
    public async Task<IEnumerable<UserDataEntity>?> GetUserData(string requesterUserName)
    {
        try
        {
            // THIS IS OUR FACADE! It will make calls to check if the requester is an admin, build the payloads, instantiate the proxy class and call on it.
            // In the proxy class, we will instantiate the gateway to make the call.
            return new List<UserDataEntity>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{nameof(UserDataService)}.{nameof(GetUserData)}: Failed while retrieving user data");
            return null;
        }
    }
}