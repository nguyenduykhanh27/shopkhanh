using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Model.Models;

namespace ShopKhanh.Data.Repositories
{
    public interface ISupportOnlineRepository : IRepository<SupportOnline>
    { }

    public class SupportOnlineRepository : RepositoryBase<SupportOnline>,ISupportOnlineRepository
    {
        public SupportOnlineRepository(DbFactory dbFactory) : base(dbFactory)
        { }
    }
}