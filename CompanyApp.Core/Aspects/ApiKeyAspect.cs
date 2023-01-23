using Castle.DynamicProxy;
using CompanyApp.Core.Interceptors;
using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CompanyApp.Core.Aspects
{
    public class ApiKeyAspect : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
            OperationContext operationContext = OperationContext.Current;
            RequestContext requestContext = operationContext.RequestContext;
            MessageHeaders headers = requestContext.RequestMessage.Headers;
            int headerValue = headers.FindHeader("ApiKey", string.Empty);
            string apiKey = (headerValue < 0) ? null : headers.GetHeader<string>(headerValue);
            var appSettings = ConfigurationManager.AppSettings;


            if (apiKey != appSettings["API_KEY"])
            {
                throw new Exception("There is no API KEY!");
            }
        }
    }
}
