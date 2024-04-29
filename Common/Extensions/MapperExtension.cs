using AutoMapper;
using FacadeAndProxyDesignPattern.Common.Documents;
using FacadeAndProxyDesignPattern.Common.Domain.Entities;
using FacadeAndProxyDesignPattern.Common.Dto.Responses;

namespace FacadeAndProxyDesignPattern.Common.Extensions;

public static class MapperExtension
{
    public static void AddMappers(this IMapperConfigurationExpression cfg)
    {
        Configure(cfg.CreateMap<UserDataResponseDto, UserDocument>());
        cfg.CreateMap<UserPostsResponseDto, UserPostDocument>().ReverseMap();
        cfg.CreateMap<Posts, UserPostDocument>().ReverseMap();
    }

    private static void Configure(IMappingExpression<UserDataResponseDto, UserDocument> mappingExpression)
    {
        mappingExpression.ForMember(dest => dest.Id, src => src.MapFrom(prop => $"{prop.UserName}-{prop.Id}"));
        mappingExpression.ForMember(dest => dest.UserName, src => src.MapFrom(prop => prop.UserName));
    }
}