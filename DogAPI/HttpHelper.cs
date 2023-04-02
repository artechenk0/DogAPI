using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DogAPI
{
    public static class HttpHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
