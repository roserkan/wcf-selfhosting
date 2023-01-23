using System;
using System.ServiceModel;

namespace CompanyApp.Host
{
    public class ServiceHostInfo<T> 
    {
        public ServiceHostInfo(ServiceHost host, Type contractType, object contract)
        {
            Host = host;
            ContractType = contractType;
        }

        public ServiceHost Host { get; set; }
        public Type ContractType { get; set; }
        public T Contract { get; set; }
    }
}
