using AutoMapper;
using ShopKhanh.Model.Models;
using ShopKhanh.Service;
using ShopKhanh.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopKhanh.Web.Controllers
{
    public class PostController : Controller
    {
        IPostCategoryService _postcategoryService;
        IPostService _postService;
        ICommonService _commonService;
        public PostController (IPostService postService,IPostCategoryService postcategoryService,ICommonService commonService)
        {
            _postService = postService;
            _postcategoryService = postcategoryService;
            _commonService = commonService;
        }


        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            var NewPostModel = _postService.PostTop(6);
            var NewPostViewModel = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(NewPostModel);
            homeViewModel.NewPost = NewPostViewModel;
            return PartialView(homeViewModel);
        }



        // GET: Post
        public ActionResult Category()
        {
            var model = _postcategoryService.GetAll();
            var listPostCategoryViewModel = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(model);
            return View(listPostCategoryViewModel);
           
        }
       
    }
}