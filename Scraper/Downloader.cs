using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HtmlAgilityPack;
using log4net;
using System.Reflection;

namespace Scraper
{
    public class Downloader
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<HtmlDocument> GetDocument(string url)
        {
            var doc = new HtmlDocument();

            try
            {
                HttpResponseMessage response = await Network.Instance.Client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                doc.LoadHtml(responseBody);
            }
            catch (HttpRequestException)
            {
                log.Warn($"Unable to download: {url}");
                return null;
            }

            return doc;
        }
    }
}
