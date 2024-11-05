using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlockChain.Domain.Models.Request;

namespace BlockChain.Domain.Models.DataBase;

public class User : DbEntity
{
    [Column("user_id")]
    [JsonPropertyName("userId")] 
    public int UserId { get; set; } = 0;
    
    [Column("curl_id")]
    [JsonPropertyName("curlid")]
    public string curlId { get; set; } = string.Empty;
        
    [Column("hash")]
    [JsonPropertyName("hach")]
    public string hash { get; set; } = string.Empty;
        
    [Column("coins")]
    [JsonPropertyName("coins")]
    public int CoinsCollected { get; set; } = 0;

    
    public User(){}
    public User(UserViewModel userViewModel)
    {
        UserId = userViewModel.UserId;
        curlId = userViewModel.CurlId;
        hash = userViewModel.Hash;
        CoinsCollected = userViewModel.Coins;
    }
}