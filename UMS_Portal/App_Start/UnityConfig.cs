using System.Web.Mvc;
using UMS_Portal.Controllers;
using UMS_Portal.Services;
using UMS_Portal.Services.Interfaces;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace UMS_Portal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMainDataAccessService, MainDataAccessService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}