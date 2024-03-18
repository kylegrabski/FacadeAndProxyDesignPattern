using FacadeAndProxyDesignPattern.Common.Documents;

namespace FacadeAndProxyDesignPattern.Common.Interfaces.Repositories;

public interface IAdminDatabaseRepository
{
    public AdminDocument GetRequesterFromDatabase(string user);
}