using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameStrix.Network
{
    static class HTTPCommunication<T> where T : class
    {
        public async static Task<T?> Get(string url)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var response = await client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                T? locRoot = JsonSerializer.Deserialize<T>(resultString);
                return locRoot;
            }
            return null;
        }

        public async static Task<T?> Post(string url, StringContent postString)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var content = postString;
            request.Content = content;
            using var response = await client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                T? locRoot = JsonSerializer.Deserialize<T>(resultString);
                return locRoot;
            }
            return null;
        }

    }
}
