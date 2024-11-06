using System.Text.Json.Serialization;

namespace BlockChain.Domain.Models.Request;

public class BlockViewModel
{
    [JsonPropertyName("id")]
    public int id { get; set; }
    
    [JsonPropertyName("current_hash")]
    public string curHash { get; set; }
    
    [JsonPropertyName("prev_hash")]
    public string prevHash { get; set; }
    
    [JsonPropertyName("is_genesis")]
    public bool genesisBlock { get; set; }
    
    [JsonPropertyName("valid_count")]
    public int validCount { get; set; }

    [JsonPropertyName("data_json")]
    public List<HashServiceModel> actions { get; set; }
}