using System.Text.Json.Serialization;
using BlockChain.Domain.Utils;

namespace BlockChain.Domain.Models.Request;

public class BlockAction
{
    [JsonPropertyName("from_hach")]
    [JsonConverter(typeof(HashDataConverter))]
    public HashData sender { get; set; }
    
    [JsonPropertyName("to_hach")]
    public string receiver { get; set; }
    
    [JsonPropertyName("prev_hash")]
    public string prevHash { get; set; }
    
    [JsonPropertyName("type_task")]
    public string typeTask  { get; set; }

    
    [JsonPropertyName("message")]
    [JsonConverter(typeof(StringToMessageDataConverter))]
    public MessageData messageData { get; set; }

    [JsonPropertyName("count_coins")]
    [JsonConverter(typeof(IntConverter))]
    public int coinsCount { get; set; }
}
