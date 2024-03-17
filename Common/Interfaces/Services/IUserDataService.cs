using FacadeAndProxyDesignPattern.Common.Domain.Entities;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Services;

public interface IUserDataService
{
    Task<IEnumerable<UserDataEntity>?> GetUserData(string requesterUserName, string userId);
}