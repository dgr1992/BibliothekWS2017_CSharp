using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BibliothekWS2017_CSharp
{
    public class RestClient
    {
        private HttpClient _client;
        private String _url;

        public RestClient(String url, String dataType)
        {
            _url = url;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(dataType));
        }

        public async Task<String> Put(String path, string data)
        {
            String result = null;
            HttpResponseMessage response = await _client.PostAsJsonAsync(path, data);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<String>();
            }
            return result;
        }

        public async Task<String> Get(String path)
        {
            String result = null;
            HttpResponseMessage response = await _client.GetAsync(_url + path);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

    }
}
