using System.Text.Json;
using FacadeAndProxyDesignPattern.Common.Documents;
using FacadeAndProxyDesignPattern.Common.Interfaces.Repositories;

namespace FacadeAndProxyDesignPattern.Implementation.Repositories;

public class AdminDatabaseRepository: IAdminDatabaseRepository
{
    private readonly ILogger _logger;

    public AdminDatabaseRepository(ILogger logger)
    {
        _logger = logger;
    }
    
    public AdminDocument? GetRequesterFromDatabase(string user)
    {
        try
        {
            List<AdminDocument>? source;
            using (StreamReader r = new StreamReader("./data.json"))
            {
                var json = r.ReadToEnd();
                source = JsonSerializer.Deserialize<List<AdminDocument>>(json);
            }

            return source?.FirstOrDefault(doc => doc.UserName.Equals(user)) ?? null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{nameof(AdminDatabaseRepository)}.{nameof(AdminDocument)}: Failed while retrieving admin user data");
            return null;
        }
    }
}