﻿using FacadeAndProxyDesignPattern.Common.Dto.Responses;

namespace FacadeAndProxyDesignPattern.Common.Domain.Entities;

public class UserDataEntity
{
    public UserDataResponseDto? UserData { get; set; }
    
    public IEnumerable<UserPostsResponseDto>? UserPosts { get; set; }
}