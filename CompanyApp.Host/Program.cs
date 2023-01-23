using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Autofac;
using Autofac.Core;
using CompanyApp.WCF.EmployeeWCF;
using Autofac.Integration.Wcf;
using System.Reflection;
using CompanyApp.WCF.ProjectWCF;
using CompanyApp.WCF.TechWCF;

namespace CompanyApp.Host
{
    internal class Program
    {
        static void Main(string[] args)
        {


            using (IContainer container = Startup.RegisterContainerBuilder().Build())
            {
                var hosts = new List<ServiceHost>()
                {
                    Startup.CreateHostWithDependencies<IProjectSRV>(typeof(ProjectSRV), container),
                    Startup.CreateHostWithDependencies<IEmployeeSRV>(typeof(EmployeeSRV), container),
                    Startup.CreateHostWithDependencies<ITechSRV>(typeof(TechSRV), container)
                };

                Startup.OpenHosts(hosts);
            }
        }
    }
}
