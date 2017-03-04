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
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;
        public HomeController(IProductCategoryService productCategoryService,ICommonService commonService,IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _commonService = commonService;
            _productService = productService;
        }
        [OutputCache(Duration =60,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlide();
            var slideView = Mapper.Map<IEnumerable< Slide>, IEnumerable< SlideViewModel >>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;

            var FuturedProductModel = _productService.GetFeatured(7);
            var topSaleProductModel = _productService.GetHotProduct(7);
            var FuturedProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(FuturedProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            homeViewModel.Featured = FuturedProductViewModel;
            homeViewModel.NewArrivals = topSaleProductViewModel;
            return View(homeViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);       
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
    
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }

        [ChildActionOnly]
        public ActionResult TopHeader()
        {
            return PartialView();
        }
    }
}