using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service_Ex
{
    public class CatService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private const string catFactsUrl =
            "https://catfact.ninja/fact";

        public CatService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<string> GetCatFactAsync()
        {
            try
            {
#nullable enable
                CatFact[]? facts = await _httpClient.GetFromJsonAsync<CatFact[]>(
                    catFactsUrl, _options);

                CatFact? fact = facts?[0];
#nullable disable
                return fact is not null
                    ? $"{fact.Fact}{Environment.NewLine}"
                    : "No Cat Facts";
            }
            catch (Exception ex)
            {
                return $"{ex}";
            }
        }
    }

    public record CatFact(string Fact, int Length);
}