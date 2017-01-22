using System;

namespace ShopKhanh.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopKhanhDbContext Init();
    }
}