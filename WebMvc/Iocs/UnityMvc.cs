using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using WebMvc.Extensions;
using WebMvc.Interfaces;
using WebMvc.Services;

namespace WebMvc.Iocs
{
    public class UnityMvc
    {
        public static void RegisterComponents()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // Database context, one per request, ensure it is disposed
            //container.BindInRequestScope<IWebDbContext, WebDbContext>();

            //Bind the various domain model services and repositories that e.g. our controllers require         
            //container.BindInRequestScope<IUnitOfWorkManager, UnitOfWorkManager>();
            container.BindInRequestScope<IUserService, UserService>();

            //container.BindInRequestScope<ISessionHelper, SessionHelper>();

            return container;
        }
    }
}