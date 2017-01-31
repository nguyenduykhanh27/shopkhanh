using AutoMapper;
using ShopKhanh.Model.Models;
using ShopKhanh.Web.Models;

namespace ShopKhanh.Web.Mappings
{
    public class AutoMappperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory,PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}