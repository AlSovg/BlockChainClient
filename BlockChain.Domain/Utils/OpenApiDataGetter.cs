using System.Text;
using System.Text.Json;
using BlockChain.Domain.Models.Request;

namespace BlockChain.Domain.Utils;

public class OpenApiDataGetter
{
    private const string _baseUrl = "https://b1.ahmetshin.com/restapi/";
    private readonly HttpClient _httpClient;
    
    public OpenApiDataGetter(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("mode", "no-cors");
    }
    public async Task<ResponseModel?> GetData(string? jsonData = null)
    {
        const string url = $"{_baseUrl}get_chains";
        using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response =  await _httpClient.PostAsync(url, content);
        var responseStream = await response.Content.ReadAsStreamAsync();
        var responseContent = await JsonSerializer.DeserializeAsync<ResponseModel>(responseStream);
        return responseContent;
    }
}