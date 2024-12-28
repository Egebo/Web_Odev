using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web_Odev.Services
{
    public class ReplicateService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReplicateService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GenerateImageAsync(string modelInput)
        {
            var client = _httpClientFactory.CreateClient("ReplicateApi");

            var content = new StringContent(JsonSerializer.Serialize(new
            {
                input = modelInput
            }), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
