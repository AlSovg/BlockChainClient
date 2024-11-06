using System.Text.Json.Serialization;
using BlockChain.Domain.Models.ViewModels;

namespace BlockChain.Domain.Models.Request.PyData;

public class PostAuthData : AuthData
{
    [JsonPropertyName("user_hash")]
    public string user_hash { get; set; } = string.Empty;
    
    [JsonPropertyName("version")]
    public string hach_version_file { get; set; } = string.Empty;
    
    [JsonPropertyName("data")]
    public SendTask data { get; set; }

    public PostAuthData(GetAuthData getAuthData)
    {
        username = getAuthData.username;
        password = getAuthData.password;
        user_hash = getAuthData.user_hash;
        hach_version_file = getAuthData.hach_version_file;
        data = getAuthData.data;
    }

}