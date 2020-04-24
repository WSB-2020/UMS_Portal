using System.Web.Mvc;
using UMS_Portal.Services;
using UMS_Portal.Services.Interfaces;
using Unity;
using Unity.Mvc5;

namespace UMS_Portal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMainDataAccessService, MainDataAccessService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}