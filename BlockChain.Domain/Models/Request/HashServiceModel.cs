using System.Text.Json.Serialization;

namespace BlockChain.Domain.Models.Request;

public class HashServiceModel
{
    public Guid Id { get; set; }
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }
    
    [JsonPropertyName("data_json")]
    public ActionViewModel ActionsViewModel { get; set; }
}