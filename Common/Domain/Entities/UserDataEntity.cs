using FacadeAndProxyDesignPattern.Common.Dto.Responses;

namespace FacadeAndProxyDesignPattern.Common.Domain.Entities;

public class UserDataEntity
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public IEnumerable<Posts>? Posts {get; set; }
}

public class Posts
{
    public string Title { get; set; }
    public string Body { get; set; }
}