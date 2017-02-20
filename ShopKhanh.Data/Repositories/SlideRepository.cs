using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Model.Models;

namespace ShopKhanh.Data.Repositories
{
    public interface ISlideRepository : IRepository<Slide>
    { }

  
    public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}