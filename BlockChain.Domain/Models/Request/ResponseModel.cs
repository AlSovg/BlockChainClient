using System.Text.Json.Serialization;
using BlockChain.Domain.Models.ViewModels;

namespace BlockChain.Domain.Models.Request;

public class ResponseModel
{
    [JsonPropertyName("success")]
    public bool Status { get; set; }
    
    [JsonPropertyName("chains")]
    public ActiveBlock ActiveBlock { get; set; }
}