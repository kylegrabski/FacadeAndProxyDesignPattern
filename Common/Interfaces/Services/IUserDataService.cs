using FacadeAndProxyDesignPattern.Common.Domain.Entities;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Services;

public interface IUserDataService
{
    Task<UserDataEntity?> GetUserData(string requesterUserName, string userId);
}