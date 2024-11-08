using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlockChain.Domain.Models.Request;
using BlockChain.Domain.Utils;

namespace BlockChain.Domain.Models.DataBase;

public class Action : DbEntity
{

    [Column("file_hash")]
    [JsonPropertyName("hach_version_file")]
    public string sender_file { get; set; }
    
    [Column("user_hash")]
    [JsonPropertyName("user_hash")]
    public string sender_user { get; set; }
    [Column("receiver")]
    [JsonPropertyName("to_hach")]
    public string receiver { get; set; }

    [Column("prev_hash")]
    [JsonPropertyName("prev_hash")]
    public string? prevHash { get; set; }

    [Column("type_task")]
    [JsonPropertyName("type_task")]
    public string typeTask { get; set; }

    [Column("action")]
    [JsonPropertyName("action")]
    public string action { get; set; } = string.Empty;

    [Column("curlId")]
    [JsonPropertyName("curlid")]
    public string curlId { get; set; } = string.Empty;

    [Column("random_key")]
    [JsonPropertyName("random_key")]
    public string key { get; set; } = string.Empty;

    [Column("random_number")]
    [JsonPropertyName("random_number")]
    public string number { get; set; } = string.Empty;

    [Column("secret")]
    [JsonPropertyName("secret_text")]
    public string secretText { get; set; } = string.Empty;

    [Column("coins_count")]
    [JsonPropertyName("count_coins")]
    [JsonConverter(typeof(IntConverter))]
    public int coinsCount { get; set; }
    
    public Action(){}

    public Action(ActionViewModel actionViewModel)
    {
        receiver = actionViewModel.receiver;
        prevHash = actionViewModel.prevHash;
        typeTask = actionViewModel.typeTask;
        coinsCount = actionViewModel.coinsCount;
        action = actionViewModel.messageData.action;
        curlId = actionViewModel.messageData.curlId;
        key = actionViewModel.messageData.key;
        number = actionViewModel.messageData.number;
        secretText = actionViewModel.messageData.secretText;
        sender_file = actionViewModel.sender.version;
        sender_user = actionViewModel.sender.user;
    }
}