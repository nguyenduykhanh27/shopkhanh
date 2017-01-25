using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Model.Models;

namespace ShopKhanh.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    { }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(DbFactory dbFactory) : base(dbFactory)
        { }
    }
}