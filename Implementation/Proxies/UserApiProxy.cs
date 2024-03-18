using FacadeAndProxyDesignPattern.Common.Domain.Entities;
using FacadeAndProxyDesignPattern.Common.Dto.Responses;
using FacadeAndProxyDesignPattern.Common.Interfaces.Gateways;
using FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;
using FacadeAndProxyDesignPattern.Common.Interfaces.Repositories;

namespace FacadeAndProxyDesignPattern.Implementation.Proxies;

public class UserApiProxy : IUserApiProxy
{
    
    private readonly ILogger _logger;
    private readonly IAdminDatabaseRepository _adminDatabaseRepository;
    private readonly IUserApiGateway _userApiGateway;

    public UserApiProxy(ILogger logger, IAdminDatabaseRepository adminDatabaseRepository, IUserApiGateway userApiGateway)
    {
        _logger = logger;
        _adminDatabaseRepository = adminDatabaseRepository;
        _userApiGateway = userApiGateway;
    }
    
    public async Task<(UserDataResponseDto?, IEnumerable<UserPostsResponseDto>?)> RequestUserData(string requester, string userId)
    {
        var adminDocument = _adminDatabaseRepository.GetRequesterFromDatabase(requester);

        var userData = await _userApiGateway.GetUserPlaceholderData(userId);

        if (!adminDocument.IsAdmin) return (userData, null);

        var userPosts = await _userApiGateway.GetUserPlaceholderPosts(userId);

        return (userData, userPosts);
    }
}