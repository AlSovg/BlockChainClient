using System.Text.Json;
using System.Text.Json.Serialization;
using BlockChain.Domain.Models.Request;

namespace BlockChain.Domain.Utils;

public class StringToMessageDataConverter : JsonConverter<MessageData>
{
    public override MessageData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string messageString = reader.GetString();

            return new MessageData
            {
                action = messageString, // Используем строку из message
                // ... (инициализация других свойств MessageData значениями по умолчанию)
            };
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            return JsonSerializer.Deserialize<MessageData>(ref reader, options);
        }

        throw new JsonException("Неверный формат для message");
    }

    public override void Write(Utf8JsonWriter writer, MessageData value, JsonSerializerOptions options)
    {
        // Начало записи объекта JSON
        writer.WriteStartObject();

        // Запись свойств в формате JSON
        writer.WriteString("action", value.action);
        writer.WriteString("curlid", value.curlId);
        writer.WriteString("random_key", value.key);
        writer.WriteString("random_number", value.number);
        writer.WriteString("secret_text", value.secretText);

        // Конец записи объекта JSON
        writer.WriteEndObject();
    }
}