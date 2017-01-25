using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKhanh.Data.Repositories
{
    public interface IPageRepository : IRepository<Page>
    { }
    public class PageRepository : RepositoryBase<Page>,IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
