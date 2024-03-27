
using System.Text;
using System.Text.Json;

namespace Orders.Frontend.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<T>(responseHttp);

                return new HttpResponseWrapper<T>(response, false, responseHttp);
            }

            return new HttpResponseWrapper<T>(default, true, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
        {
            var menssageJson = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(menssageJson, Encoding.UTF8, "application/json");
            var responseHtttp = await _httpClient.PostAsync(url, messageContent);

            return new HttpResponseWrapper<object>(null, !responseHtttp.IsSuccessStatusCode, responseHtttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model)
        {
            var menssageJson = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(menssageJson, Encoding.UTF8, "application/json");
            var responseHtttp = await _httpClient.PostAsync(url, messageContent);
            if (responseHtttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<TActionResponse>(responseHtttp);
                return new HttpResponseWrapper<TActionResponse>(default, true, responseHtttp);
            }

            return new HttpResponseWrapper<TActionResponse>(default, true, responseHtttp);

        }

        private async Task<T> UnserializeAnswer<T>(HttpResponseMessage responseHttp)
        {
            var response = await responseHttp.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(response, _jsonDefaultOptions)!;
        }

    }
}
