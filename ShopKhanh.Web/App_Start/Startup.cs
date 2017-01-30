using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;
using ShopKhanh.Data.Infrastructure;
using ShopKhanh.Data;
using ShopKhanh.Data.Repositories;
using ShopKhanh.Service;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(ShopKhanh.Web.App_Start.Startup))]

namespace ShopKhanh.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //Register your Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<ShopKhanhDbContext>().AsSelf().InstancePerRequest();

            //Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();
            //Services
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
                .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
               
        }
    }
}
