using AutoMapper;
using FacadeAndProxyDesignPattern.Common.Extensions;
using FacadeAndProxyDesignPattern.Common.Interfaces.Gateways;
using FacadeAndProxyDesignPattern.Common.Interfaces.Proxies;
using FacadeAndProxyDesignPattern.Common.Interfaces.Repositories;
using FacadeAndProxyDesignPattern.Common.Interfaces.Services;
using FacadeAndProxyDesignPattern.Implementation.Gateways;
using FacadeAndProxyDesignPattern.Implementation.Proxies;
using FacadeAndProxyDesignPattern.Implementation.Repositories;
using FacadeAndProxyDesignPattern.Implementation.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FacadeAndProxyDesignPattern.Implementation.Extensions;

public static class ContainerRegistrations
{
    public static void AddRegistrations(this IServiceCollection services, IConfiguration configuration)
    {
        /* Setup Dependency Injection */
        services.AddSingleton(new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(120),
        });
        services.AddMemoryCache();
        
        #region Gateways
        services.AddSingleton<IUserApiGateway>(provider => new UserApiGateway(
            provider.GetService<HttpClient>()!,
            provider.GetService<IMapper>()!,
            provider.GetService<ILogger>()!));
        #endregion
        
        #region Proxies

        services.AddSingleton <IUserApiProxy>(provider => new UserApiProxy(
            provider.GetService<ILogger>()!,
            provider.GetService<IAdminDatabaseRepository>()!,
            provider.GetService<IMapper>()!,
            provider.GetService<IUserApiGateway>()!));
        #endregion
        
        #region Repositories

        services.AddSingleton<IAdminDatabaseRepository>(provider => new AdminDatabaseRepository(
            provider.GetService<ILogger>()!));

        #endregion
        
        #region Services

        services.AddSingleton<IUserDataService>(provider => new UserDataService(
            provider.GetService<ILogger>()!,
            provider.GetService<IMapper>()!,
            provider.GetService<IUserApiProxy>()!));

        #endregion

        var mapperConfig = new MapperConfiguration(cfg => cfg.AddMappers());
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}