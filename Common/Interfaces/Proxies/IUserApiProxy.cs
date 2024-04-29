using FacadeAndProxyDesignPattern.Common.Domain.Entities;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;

public interface IUserApiProxy
{
    Task<UserDataEntity> RequestUserData(string requester, string userId);
}