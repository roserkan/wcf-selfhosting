using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CompanyApp.Core.Utilities.SoapHeader
{
    public class SoapHeader
    {
        public string GetHeader(string name, string ns)
        {
            OperationContext operationContext = OperationContext.Current;
            RequestContext requestContext = operationContext.RequestContext;
            MessageHeaders headers = requestContext.RequestMessage.Headers;


            int headerValue = headers.FindHeader(name, ns);
            if (headerValue < 0) return null;

            return headers.GetHeader<string>(headerValue);
        }
    }
}
