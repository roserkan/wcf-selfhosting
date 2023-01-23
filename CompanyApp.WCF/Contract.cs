using CompanyApp.WCF.EmployeeWCF;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CompanyApp.WCF
{
     //EmployeeSRVClient : System.ServiceModel.ClientBase<EmoployeeSRV.IEmployeeSRV>, EmoployeeSRV.IEmployeeSRV
    public abstract class Contract
    {
        public virtual void CustomHeader<T>(System.ServiceModel.ClientBase<T> client)
            where T : class
        {
            EndpointAddressBuilder addressBuilder = new EndpointAddressBuilder(client.Endpoint.Address);

            addressBuilder.Headers.Add(AddressHeader.CreateAddressHeader("Username", string.Empty, "bsenyurt"));
            client.Endpoint.Address = addressBuilder.ToEndpointAddress();
        }
    }
}
