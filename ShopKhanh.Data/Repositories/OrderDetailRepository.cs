using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKhanh.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    { }
    public class OrderDetailRepository :RepositoryBase<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}
