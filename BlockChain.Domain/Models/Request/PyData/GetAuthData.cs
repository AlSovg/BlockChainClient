using System.Text.Json.Serialization;

namespace BlockChain.Domain.Models.Request.PyData;

public class GetAuthData : AuthData
{

    [JsonPropertyName("user_hash")]
    public string user_hash { get; set; } = string.Empty;
    
    [JsonPropertyName("hach_version_file")]
    public string hach_version_file { get; set; } = string.Empty;
    
    [JsonPropertyName("data")]
    public string data { get; set; } = string.Empty;


}