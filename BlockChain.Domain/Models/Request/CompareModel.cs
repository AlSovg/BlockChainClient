using System.Text.Json.Serialization;

namespace BlockChain.Domain.Models.Request;

public class CompareModel
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }
    
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    public CompareModel()
    {
    }
}

public class SuccessCompareModel : CompareModel
{
    public SuccessCompareModel()
    {
        Status = true;
        Message = "Данные синхронизированы";
    }
}

public class FailCompareModel : CompareModel
{
    public FailCompareModel()
    {
        Status = false;
        Message = "Синхронизация данных не требуется";
    }
}