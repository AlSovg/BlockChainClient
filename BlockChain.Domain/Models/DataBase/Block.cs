using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlockChain.Domain.Models.Request;

namespace BlockChain.Domain.Models.DataBase;

public class Block : DbEntity
{
    
    [Column("block_id")]
    [JsonPropertyName("id")] 
    public int BlockId { get; set; } = 0;
    
    [Column("cur_hash")]
    [JsonPropertyName("current_hash")]
    public string CurHash { get; set; } = string.Empty;
    
    [Column("prev_hash")]
    [JsonPropertyName("prev_hash")]
    public string PrevHash { get; set; } = string.Empty;
    
    [Column("is_genesis")]
    [JsonPropertyName("is_genesis")]
    public bool GenesisBlock { get; set; } =  false;

    [Column("valid_count")]
    [JsonPropertyName("valid_count")] 
    public int ValidCount { get; set; } = 0;
    
    public Block(){}
    
    public Block(BlockViewModel block)
    {
        Id = block.Id;
        BlockId = block.BlockId;
        CurHash = block.CurHash;
        PrevHash = block.PrevHash;
        GenesisBlock = block.GenesisBlock;
        ValidCount = block.ValidCount;
    }
}