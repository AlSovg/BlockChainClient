using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlockChain.Domain.Enums;

public enum CommandType
{
    [Display(Name = "Монеты")]
    [JsonPropertyName("send_coins")]
    SendCoins = 1,
    
    [Display(Name = "Сообщение")]
    [JsonPropertyName("custom")]
    SendMessage = 2
    
}