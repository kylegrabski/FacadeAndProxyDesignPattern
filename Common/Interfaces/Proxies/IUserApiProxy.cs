using FacadeAndProxyDesignPattern.Common.Dto.Responses;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;

public interface IUserApiProxy
{
    Task<IEnumerable<UserDataResponseDto>> RequestUserData(string requester);
}