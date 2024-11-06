using System.Text.Json.Serialization;
using BlockChain.Domain.Models.ViewModels;

namespace BlockChain.Domain.Models.Request;

public class ResponseModel
{
    public ResponseModel(ActiveBlock activeBlock)
    {
        ActiveBlock = activeBlock;
    }

    [JsonPropertyName("success")]
    public bool Status { get; set; }
    
    [JsonPropertyName("chains")]
    public ActiveBlock ActiveBlock { get; set; }
}
