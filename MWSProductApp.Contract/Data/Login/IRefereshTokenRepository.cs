using System;
using MWSProductApp.Model;

namespace MWSProductApp.Contract.Data.Login;

public interface IRefereshTokenRepository
{
       Task StoreRefreshTokenAsync(Guid userId, string refreshToken);
       Task<MWSRefreshToken> GetRefreshTokenAsync(Guid userId);
}
