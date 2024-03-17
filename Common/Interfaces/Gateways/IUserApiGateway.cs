using FacadeAndProxyDesignPattern.Common.Dto.Responses;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Gateways;

public interface IUserApiGateway
{
    public Task<UserDataResponseDto?> GetUserPlaceholderData(string userId);
    public Task<IEnumerable<UserPostsResponseDto>> GetUserPlaceholderPosts(string userId);
}