using System.Text.Json;
using System.Text.Json.Serialization;
using BlockChain.Domain.Models.Request;

namespace BlockChain.Domain.Utils;

public class HashDataConverter : JsonConverter<HashData>
{
    public override HashData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            // Преобразуем строку в объект HashData
            return new HashData
            {
                user = reader.GetString() // Используем строку из sender для user
            };
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            // Десериализуем в объект HashData
            return JsonSerializer.Deserialize<HashData>(ref reader, options);
        }

        throw new JsonException("Неверный формат для sender: ожидается строка или объект.");
    }

    public override void Write(Utf8JsonWriter writer, HashData value, JsonSerializerOptions options)
    {
        writer.WriteStartObject(); // Начало объекта JSON

        writer.WriteString("hach_version_file", value.version); // Запись свойства version
        writer.WriteString("user_hash", value.user); // Запись свойства user

        writer.WriteEndObject();
    }
}