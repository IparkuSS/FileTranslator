using System.Net.Http;

namespace Parser.PL.HttpClients
{
    public class TranslatorHttpClient : HttpClient
    {
        public TranslatorHttpClient(HttpClient httpClient)
        {
            this.BaseAddress = httpClient.BaseAddress;
        }
    }
}
