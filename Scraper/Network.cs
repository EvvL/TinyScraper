using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net;

namespace Scraper
{
    class Network
    {
        private static readonly Lazy<Network> lazy = new Lazy<Network>(() => new Network());

        public static Network Instance { get { return lazy.Value; } }

        public HttpClient Client;

        private Network()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            ServicePointManager.ServerCertificateValidationCallback =
                        delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                        {
                            return true;
                        };

            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36");
        }
    }
}
