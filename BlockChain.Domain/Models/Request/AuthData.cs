using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlockChain.Domain.Models.Request;

public class AuthData
{

    [Display(Name = "Логин")]
    [JsonPropertyName("username")]
    public string username { get; set; } = string.Empty;
    
    [Display(Name = "Пароль")]
    [JsonPropertyName("password")]
    public string password { get; set; } = string.Empty;

}