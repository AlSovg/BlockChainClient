using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BlockChain.Domain.Models.DataBase;

namespace BlockChain.Domain.Models.Request;

public class BlockViewModel
{
    [Key]
    [JsonPropertyName("dbId")]
    public virtual Guid Id { get; set; } = Guid.NewGuid();

    [JsonPropertyName("id")]
    public int BlockId { get; set; }
    
    [JsonPropertyName("current_hash")]
    public string CurHash { get; set; }
    
    [JsonPropertyName("prev_hash")]
    public string? PrevHash { get; set; } 
    
    [JsonPropertyName("is_genesis")]
    public bool GenesisBlock { get; set; } 

    [JsonPropertyName("valid_count")] 
    public int ValidCount { get; set; } 

    [JsonPropertyName("data_json")]
    public List<HashServiceModel> Actions { get; set; } = new List<HashServiceModel>();

    public BlockViewModel(){}
    public BlockViewModel(Block block)
    {
        BlockId = block.BlockId;
        CurHash = block.CurHash;
        PrevHash = block.PrevHash;
        GenesisBlock = block.GenesisBlock;
        ValidCount = block.ValidCount;
    }
}