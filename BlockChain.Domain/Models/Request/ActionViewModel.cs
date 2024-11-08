using System.Text.Json.Serialization;
using BlockChain.Domain.Utils;
using Action = BlockChain.Domain.Models.DataBase.Action;

namespace BlockChain.Domain.Models.Request;

public class ActionViewModel
{
    [JsonPropertyName("dbId")]
    public  Guid Id { get; set; } = Guid.NewGuid();
    [JsonPropertyName("from_hach")]
    [JsonConverter(typeof(HashDataConverter))]
    public HashData sender { get; set; }
    
    [JsonPropertyName("to_hach")]
    public string? receiver { get; set; }
    
    [JsonPropertyName("prev_hash")]
    public string? prevHash { get; set; }
    
    [JsonPropertyName("type_task")]
    public string? typeTask  { get; set; }

    
    [JsonPropertyName("message")]
    [JsonConverter(typeof(StringToMessageDataConverter))]
    public MessageData messageData { get; set; }

    [JsonPropertyName("count_coins")]
    [JsonConverter(typeof(IntConverter))]
    public int coinsCount { get; set; }
    
    public ActionViewModel(){}

    public ActionViewModel(Action action)
    {
        sender = new HashData()
        {
            user = action.sender_user,
            version = action.sender_file,
        };
        receiver = action.receiver;
        prevHash = action.prevHash;
        typeTask = action.typeTask;
        coinsCount = action.coinsCount;
        messageData = new MessageData()
        {
            action = action.action,
            curlId = action.curlId,
            key = action.key,
            number = action.number,
            secretText = action.secretText
        };
    }
    
    
}
