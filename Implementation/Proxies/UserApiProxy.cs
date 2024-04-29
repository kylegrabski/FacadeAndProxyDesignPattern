using AutoMapper;
using FacadeAndProxyDesignPattern.Common.Documents;
using FacadeAndProxyDesignPattern.Common.Domain.Entities;
using FacadeAndProxyDesignPattern.Common.Interfaces.Gateways;
using FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;
using FacadeAndProxyDesignPattern.Common.Interfaces.Repositories;

namespace FacadeAndProxyDesignPattern.Implementation.Proxies;

public class UserApiProxy : IUserApiProxy
{
    
    private readonly ILogger _logger;
    private readonly IAdminDatabaseRepository _adminDatabaseRepository;
    private readonly IMapper _mapper;
    private readonly IUserApiGateway _userApiGateway;

    public UserApiProxy(ILogger logger, IAdminDatabaseRepository adminDatabaseRepository, IMapper mapper, IUserApiGateway userApiGateway)
    {
        _logger = logger;
        _adminDatabaseRepository = adminDatabaseRepository;
        _mapper = mapper;
        _userApiGateway = userApiGateway;
    }
    
    public async Task<UserDataEntity> RequestUserData(string requester, string userId)
    {
        var adminDocument = _adminDatabaseRepository.GetRequesterFromDatabase(requester);

        var userData = await _userApiGateway.GetUserPlaceholderData(userId);
        
        var userDataEntity = new UserDataEntity()
        {
            Id = userData.Id,
            UserName = userData.UserName,
        };

        if (!adminDocument.IsAdmin) return userDataEntity;

        var userPosts = await _userApiGateway.GetUserPlaceholderPosts(userId);

        userDataEntity.Posts = _mapper.Map<IEnumerable<Posts>>(userPosts);
        
        return userDataEntity;
    }
}