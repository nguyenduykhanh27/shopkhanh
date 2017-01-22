namespace ShopKhanh.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopKhanhDbContext dbContext;

        public ShopKhanhDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopKhanhDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}