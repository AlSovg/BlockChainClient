using System.Text.Json.Serialization;
using BlockChain.Domain.Models.DataBase;
using BlockChain.Domain.Models.Request;

namespace BlockChain.Domain.Models.ViewModels;

public class ActiveBlock
{
    [JsonPropertyName("block_active")]
    public List<BlockViewModel> Blocks { get; set; }
    
    [JsonPropertyName("users_block")]
    public List<UserViewModel> Users { get; set; }

}