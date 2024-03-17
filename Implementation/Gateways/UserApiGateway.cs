using FacadeAndProxyDesignPattern.Common.Dto.Responses;
using FacadeAndProxyDesignPattern.Common.Interfaces.Gateways;
using Newtonsoft.Json;

namespace FacadeAndProxyDesignPattern.Implementation.Gateways;

public class UserApiGateway: IUserApiGateway
{
    private readonly string _baseUrl;
    private readonly HttpClient _client;
    private readonly ILogger _logger;

    public UserApiGateway(HttpClient client, ILogger logger)
    {
        _client = client;
        _baseUrl = "https://jsonplaceholder.typicode.com";
        _logger = logger;
    }
    public async Task<UserDataResponseDto?> GetUserPlaceholderData(string userId)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/users/{userId}");
            var response = await _client.SendAsync(request);

            if (response?.IsSuccessStatusCode != true)
            {
                _logger.LogError(
                    $"{nameof(UserApiGateway)}.{nameof(GetUserPlaceholderData)}. Failed to get User Placeholder Data. {JsonConvert.SerializeObject(response)}");
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var results = JsonConvert.DeserializeObject<UserDataResponseDto>(responseString);
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{nameof(UserApiGateway)}.{nameof(GetUserPlaceholderData)}. Failure encountered while fetching User Placeholder Data");
            return null;
        }
    }

    public async Task<IEnumerable<UserPostsResponseDto>> GetUserPlaceholderPosts(string userId)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/posts?userId={userId}");
            var response = await _client.SendAsync(request);

            if (response?.IsSuccessStatusCode != true)
            {
                _logger.LogError(
                    $"{nameof(UserApiGateway)}.{nameof(GetUserPlaceholderPosts)}. Failed to get User Placeholder Data. {JsonConvert.SerializeObject(response)}");
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var results = JsonConvert.DeserializeObject<IEnumerable<UserPostsResponseDto>>(responseString);
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{nameof(UserApiGateway)}.{nameof(GetUserPlaceholderPosts)}. Failure encountered while fetching User Placeholder Data");
            return null;
        }
    }
}