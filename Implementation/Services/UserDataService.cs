using AutoMapper;
using FacadeAndProxyDesignPattern.Common.Domain.Entities;
using FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;
using FacadeAndProxyDesignPattern.Common.Interfaces.Services;

namespace FacadeAndProxyDesignPattern.Implementation.Services;

public class UserDataService : IUserDataService
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IUserApiProxy _userApiProxy;

    public UserDataService(ILogger logger, IMapper mapper, IUserApiProxy userApiProxy)
    {
        _logger = logger;
        _mapper = mapper;
        _userApiProxy = userApiProxy;
    }
    
    public async Task<UserDataEntity?> GetUserData(string requesterUserName, string userId)
    {
        try
        {
            var userDataEntity = await _userApiProxy.RequestUserData(requesterUserName, userId);

            return userDataEntity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{nameof(UserDataService)}.{nameof(GetUserData)}: Failed while retrieving user data");
            return null;
        }
    }
}