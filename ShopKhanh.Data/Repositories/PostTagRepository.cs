using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKhanh.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag>
    { }
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(DbFactory dbFactory) : base(dbFactory)
        { }
    }
}
