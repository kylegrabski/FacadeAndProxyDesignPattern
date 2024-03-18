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
    
    public async Task<UserDataEntity?> GetUserData(string requesterUserName, string userId)
    {
        try
        {
            var (userData, userPosts) = await _userApiProxy.RequestUserData(requesterUserName, userId); // @TODO CHECK FOR NULL
            var userEntity = new UserDataEntity()
            {
                UserData = userData
            };
            
            if (userPosts != null)
            {
                userEntity.UserPosts = userPosts;
            }

            return userEntity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{nameof(UserDataService)}.{nameof(GetUserData)}: Failed while retrieving user data");
            return null;
        }
    }
}