using System.Text.Json.Serialization;

namespace FacadeAndProxyDesignPattern.Common.Documents;

public class AdminDocument
{
    [JsonPropertyName("userName")]
    public string UserName { get; set; }
    
    [JsonPropertyName("isAdmin")]
    public bool IsAdmin { get; set; }
}