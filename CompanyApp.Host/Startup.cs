using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Wcf;
using Castle.DynamicProxy;
using CompanyApp.Business.Abstract;
using CompanyApp.Business.Concrete;
using CompanyApp.Core.Interceptors;
using CompanyApp.DataAccess.Abstract;
using CompanyApp.DataAccess.Concrete.EFRepositories;
using CompanyApp.Host.Interceptors;
using CompanyApp.WCF;
using CompanyApp.WCF.EmployeeWCF;
using CompanyApp.WCF.ProjectWCF;
using CompanyApp.WCF.TechWCF;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace CompanyApp.Host
{
    internal class Startup
    {
        public static ContainerBuilder RegisterContainerBuilder()
        {
            //var config = GlobalConfiguration.Configuration;
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            //                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            ContainerBuilder builder = new ContainerBuilder();

            builder.Register(c => new EFEmployeeRepository()).As<IEmployeeRepository>();
            builder.Register(c => new EmployeeService(c.Resolve<IEmployeeRepository>())).As<IEmployeeService>();
            builder.Register(c => new EmployeeSRV(c.Resolve<IEmployeeService>())).As<IEmployeeSRV>();


            builder.Register(c => new EFProjectRepository()).As<IProjectRepository>();
            builder.Register(c => new ProjectService(c.Resolve<IProjectRepository>())).As<IProjectService>();
            builder.Register(c => new ProjectSRV(c.Resolve<IProjectService>())).As<IProjectSRV>();


            builder.Register(c => new EFTechRepository()).As<ITechRepository>();
            builder.Register(c => new TechService(c.Resolve<ITechRepository>())).As<ITechService>();
            builder.Register(c => new TechSRV(c.Resolve<ITechService>())).As<ITechSRV>();


            var assembly = System.Reflection.Assembly.GetAssembly(typeof(EmployeeSRV));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

            return builder;
        }

        public static ServiceHost CreateHostWithDependencies<T>(Type hostType, IContainer container)
            where T : IContract
        {
            ServiceHost host = new ServiceHost(hostType);

            IComponentRegistration registration;
            if (!container.ComponentRegistry.TryGetRegistration(new TypedService(typeof(T)), out registration))
            {
                Console.WriteLine("The service contract has not been registered in the container.");
                Console.ReadLine();
            }

            host.AddDependencyInjectionBehavior<T>(container);
            return host;
        }

        public static void OpenHosts(List<ServiceHost> hosts)
        {
            foreach (var host in hosts)
            {
                host.Open();
                Console.WriteLine(host.Description.Name + " host has started");
            }
            Console.ReadLine();

        }

    }
}
