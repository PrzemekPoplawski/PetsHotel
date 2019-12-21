using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PetsHotel.webapp.Repositories;
using PetsHotel.webapp.Service;

namespace PetsHotel.webapp.App_Start
{
    public class DependencyInjectionResolver
    {
        public static void RegisterComponent() 
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Dane sprzedazowe - OlapService łączył się z bazami olap

            // Dane sprzedżowe które sa fejkowe


        }
    }
}