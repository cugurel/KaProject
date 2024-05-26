using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EfRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Customer classı bağımlılık yönetimi
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerRepository>().As<ICustomerDal>().SingleInstance();

            //Year classı bağımlılık yönetimi
            builder.RegisterType<YearManager>().As<IYearService>().SingleInstance();
            builder.RegisterType<EfYearRepository>().As<IYearDal>().SingleInstance();

            //Car classı bağımlılık yönetimi
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarRepository>().As<ICarDal>().SingleInstance();

            //Category classı bağımlılık yönetimi
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryDal>().SingleInstance();

            //Gallery classı bağımlılık yönetimi
            builder.RegisterType<GalleryManager>().As<IGalleryService>().SingleInstance();
            builder.RegisterType<EfGalleryRepository>().As<IGalleryDal>().SingleInstance();
        }
    }
}
