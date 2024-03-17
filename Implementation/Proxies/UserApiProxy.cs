using FacadeAndProxyDesignPattern.Common.Dto.Responses;
using FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;
using FacadeAndProxyDesignPattern.Common.Interfaces.Repositories;

namespace FacadeAndProxyDesignPattern.Implementation.Proxies;

public class UserApiProxy : IUserApiProxy
{
    
    private readonly ILogger _logger;
    private readonly IAdminDatabaseRepository _adminDatabaseRepository;

    public UserApiProxy(ILogger logger, IAdminDatabaseRepository adminDatabaseRepository)
    {
        _logger = logger;
        _adminDatabaseRepository = adminDatabaseRepository;
    }
    
    // If the username doesn't exist in the database, isAdmin: false
    public Task<IEnumerable<UserDataResponseDto>> RequestUserData(string requester)
    {
        var isAdmin = _adminDatabaseRepository.GetUserFromDatabase(requester);
        
        return null;
    }
}