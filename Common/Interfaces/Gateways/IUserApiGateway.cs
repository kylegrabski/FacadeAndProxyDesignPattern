using FacadeAndProxyDesignPattern.Common.Documents;
using FacadeAndProxyDesignPattern.Common.Dto.Responses;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Gateways;

public interface IUserApiGateway
{
    public Task<UserDocument?> GetUserPlaceholderData(string userId);
    public Task<IEnumerable<UserPostDocument>> GetUserPlaceholderPosts(string userId);
}