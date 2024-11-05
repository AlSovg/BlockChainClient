using System.Text.Json.Serialization;
using BlockChain.Domain.Models.DataBase;

namespace BlockChain.Domain.Models.Request;
public class UserViewModel
{
    [JsonPropertyName("dbId")]
    public virtual Guid Id { get; set; } = Guid.NewGuid();
    
    [JsonPropertyName("id")]
    public int UserId { get; set; }
    [JsonPropertyName("hach")]
    public string Hash { get; set; }
    [JsonPropertyName("coins")]
    public int Coins { get; set; }

    [JsonPropertyName("curlid")]
    public string CurlId { get; set; }
    
    public UserViewModel(){}
    public UserViewModel(User user)
    {
        
        UserId = user.UserId;
        Hash = user.hash;
        Coins = user.CoinsCollected;
        CurlId = user.curlId;
    }
}