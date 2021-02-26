using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AdminPortal
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url)
            => JsonConvert.DeserializeObject<T>(await httpClient.GetStringAsync(url));

        public static async Task<HttpResponseMessage> SendJsonAsync<T>(
            this HttpClient httpClient, 
            HttpMethod method, 
            string url, T item)
            => await httpClient.SendAsync(new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(item)),
                RequestUri = new Uri(url),
                Method = method
            });
    }
}