using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlockChain.Domain.Models.Request;

public class HashData
{
    [Key] // Указываем, что это первичный ключ
    public Guid Id { get; set; } // Или другой тип, в зависимости от вашей модели
    
    [JsonPropertyName("hach_version_file")]
    public string? version { get; set; }
    
    [JsonPropertyName("user_hash")]
    public string? user { get; set; }
}