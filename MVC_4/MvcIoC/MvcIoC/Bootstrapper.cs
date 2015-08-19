using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcIoC.Models;
using System.Web.Configuration;

namespace MvcIoC
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initalise ()
        {
            var container = BuildUnityContainer();
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer ()
        {
            var container = new UnityContainer();

            //register all your componenets with the container here
            //it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService();

            RegisterTypes(container);
            return container;

        }
        public static void RegisterTypes ( IUnityContainer container )
        {
            //  container.RegisterTypes(AllClasses.FromAssemblies(), WithMappings.FromMatchingInterface, WithName.Default);

            //container.RegisterType<IProteinRespository, ProteinRespository>(new InjectionConstructor("test data source"));
            //container.RegisterInstance(typeof(IProteinRespository), new ProteinRespository("test data source 123));

            container.RegisterType<IProteinRespository, ProteinRespository>("StandardRepository", new InjectionConstructor("test"));
            container.RegisterType<IProteinRespository, DebugProteinRespository>("DebugRepository");

            var repositoryType = WebConfigurationManager.AppSettings["RepositoryType"];
            container.RegisterType<IProteinTrackingService, ProteinTrackingService>(
            new InjectionConstructor(container.Resolve<IProteinRespository>(repositoryType)));


            container.RegisterType<IProteinTrackingService, ProteinTrackingService>();
            container.RegisterType<IProteinRespository, ProteinRespository>();
        }
    }

    public class DebugProteinRespository : IProteinRespository
    {
        public ProteinData GetData ( DateTime dateTime )
        {
            throw new NotImplementedException();
        }

        public void SetGoal ( DateTime dateTime, int value )
        {
            throw new NotImplementedException();
        }

        public void SetTotal ( DateTime dateTime, int value )
        {
            throw new NotImplementedException();
        }
    }
}