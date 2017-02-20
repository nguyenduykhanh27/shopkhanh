namespace ShopKhanh.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopKhanh.Data.ShopKhanhDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopKhanh.Data.ShopKhanhDbContext context)
        {
            CreateUser(context);
            CreateProductCategorySample(context);
            CreateSlide(context);
            //  This method will be called after migrating to the latest version.
          
        }
        private void CreateUser(ShopKhanhDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopKhanhDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopKhanhDbContext()));
            var user = new ApplicationUser()
            {
                UserName = "shopkhanh",
                Email = "duykhanhkontum123@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Technology Education"
            };
            manager.Create(user, "123456");
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }
            var adminUser = manager.FindByEmail("duykhanhkontum123@gmail.com");
            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateProductCategorySample(ShopKhanh.Data.ShopKhanhDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                   new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
        private void CreateFooter(ShopKhanhDbContext context)
        {

            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                context.Footers.Add(new Footer()
                {
                    ID = CommonConstants.DefaultFooterId,
                    Content = content
                });
                context.SaveChanges();
            }
        }
        private void CreateSlide(ShopKhanhDbContext context)
        {

            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,Url="#",
                        Image ="~/Assets/client/images/slider/img-04.png",
                        Description =@"<h1 class=""title1"">headphones az12</h1>
                                        <h2 class=""title2"">Typi non habent claritatem insitam; est usus legentis</h2>"

                    },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,Status=true,
                        Url ="#",
                        Image ="~/Assets/client/images/slider/img-05.png",
                        Description = @"<h1 class=""title1"">Samsung s5</h1>
                                         <h2 class=""title2"">Typi non habent claritatem insitam; est usus legentis</h2>"
                    }
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
               
            }
        }
    }
}
