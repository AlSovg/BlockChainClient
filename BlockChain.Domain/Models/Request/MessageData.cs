using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlockChain.Domain.Models.Request;

public class MessageData
{
    [Key]
    public Guid Id { get; set; }
    [JsonPropertyName("action")]
    public string? action { get; set; } = string.Empty;
    
    [JsonPropertyName("curlid")]
    public string? curlId { get; set; } = string.Empty;
    
    [JsonPropertyName("random_key")]
    public string? key { get; set; } = string.Empty;
    
    [JsonPropertyName("random_number")]
    public string? number { get; set; } = string.Empty;
    
    [JsonPropertyName("secret_text")]
    public string? secretText { get; set; } = string.Empty;
}