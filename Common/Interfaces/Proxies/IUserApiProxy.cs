using FacadeAndProxyDesignPattern.Common.Domain.Entities;
using FacadeAndProxyDesignPattern.Common.Dto.Responses;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;

public interface IUserApiProxy
{
    Task<(UserDataResponseDto?, IEnumerable<UserPostsResponseDto>?)> RequestUserData(string requester, string userId);
}