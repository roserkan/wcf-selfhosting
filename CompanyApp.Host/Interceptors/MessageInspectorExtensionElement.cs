using System;
using System.ServiceModel.Configuration;

namespace CompanyApp.Host.Interceptors
{
    public class MessageInspectorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(MessageInspectorEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new MessageInspectorEndpointBehavior();
        }
    }
}
