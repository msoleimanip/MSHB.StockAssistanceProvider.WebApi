﻿using System;
using System.Threading.Tasks;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts
{
    public interface ITokenStoreService
    {
        Task AddUserTokenAsync(UserToken userToken);
        Task AddUserTokenAsync(User user, string refreshToken, string accessToken, string refreshTokenSource);
        Task<bool> IsValidTokenAsync(string accessToken, Guid userId);
        Task<UserToken> FindTokenLoginAsync(string refreshToken);
        Task DeleteExpiredTokensAsync();
        Task<UserToken> FindTokenAsync(string refreshToken);
        Task DeleteTokenAsync(string refreshToken);
        Task DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource);
        Task InvalidateUserTokensAsync(Guid userId);
        Task<(string accessToken, string refreshToken)> CreateJwtTokens(User user, string refreshTokenSource);
        Task RevokeUserBearerTokensAsync(string userIdValue, string refreshToken);
    }
}
