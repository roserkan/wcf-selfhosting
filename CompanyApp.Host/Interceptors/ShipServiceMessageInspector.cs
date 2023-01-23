using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace CompanyApp.Host.Interceptors
{
    public class ShipServiceMessageInspector: IDispatchMessageInspector
    {
        // Operasyon talebi servis tarafına ulaştıkan sonra devreye giriyor olacak 
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            System.Console.WriteLine("Agam be");
            // Gelen request nesnesinin içeriği ele alınır ;)

            return null;
        }

        // Cevap istemci tarafına gönderilmeden önce çağırılacak. Tabi eğer istisnai bir durum oluşmamışsa 
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            System.Console.WriteLine("Agam b 22e");
        }
    }
}
