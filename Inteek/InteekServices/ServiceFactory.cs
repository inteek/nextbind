
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InteekServices
{
    public class ServiceFactory<T> where T : class
    {
        private T _service;
        public T GetService(string address)
        {
            return _service ?? (_service = GetServiceInstance(address));
        }

        private T GetServiceInstance(string address)
        {
            string UrlService = ConfigurationManager.AppSettings["urlService"];

            BasicHttpBinding binding = new BasicHttpBinding();

            binding.MaxBufferSize = 2147483647;
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxReceivedMessageSize = 2147483647;
            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);


            EndpointAddress endpoint = new EndpointAddress(UrlService + address);

            return ChannelFactory<T>.CreateChannel(binding, endpoint);
        }
    }
}
