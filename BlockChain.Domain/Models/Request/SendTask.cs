using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BlockChain.Domain.Enums;
using BlockChain.Utils;

namespace BlockChain.Domain.Models.Request;

public class SendTask
{

    [Display(Name = "Тип задачи")]
    [JsonPropertyName("type_task")] 
    [JsonConverter(typeof(CommandTypeConverter))]
    public CommandType typeTask { get; set; }
    
    [Display(Name = "Отправитель")]
    [JsonPropertyName("from_hach")]
    public string Reciever { get; set; } = string.Empty;
    
    [Display(Name = "Получатель")]
    [JsonPropertyName("to_hach")]
    public string Sender { get; set; } = string.Empty;

    [Display(Name = "Кол-во монет")]
    [JsonPropertyName("count_coins")] 
    public int CoinsCount { get; set; } = 0;
    
    [Display(Name = "Текст сообщения")]
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}