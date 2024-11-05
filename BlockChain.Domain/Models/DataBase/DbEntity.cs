using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlockChain.Domain.Models.DataBase;

public class DbEntity
{
    [Key]
    [JsonPropertyName("id")]
    [Column("id")]
    public Guid Id { get; set; }
}