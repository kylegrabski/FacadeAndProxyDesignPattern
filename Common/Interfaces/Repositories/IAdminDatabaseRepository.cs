using FacadeAndProxyDesignPattern.Common.Documents;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Repositories;

public interface IAdminDatabaseRepository
{
    public AdminDocument GetUserFromDatabase(string user);
}