using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKhanh.Data.Repositories
{
    public interface ISystemConfigRepository : IRepository<SystemConfig>
    { }
    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(DbFactory dbFactory) : base(dbFactory)
        { }

    }
}
