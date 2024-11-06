using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlockChain.Domain.Utils;

public class IntConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            // Проверяем, что значение в пределах диапазона int
            if (reader.TryGetInt32(out int intValue))
            {
                return intValue; // Возвращаем число
            }
            else
            {
                return 0; // Возвращаем 0, если значение выходит за пределы диапазона int
            }
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            if (int.TryParse(reader.GetString(), out int intValue))
            {
                return intValue; // Возвращаем число, если преобразование успешно
            }
            else
            {
                return 0; // Возвращаем 0, если преобразование не удалось
            }
        }
        else
        {
            throw new JsonException($"Неверный тип для count_coins: ожидается число или строка, а получено {reader.TokenType}.");
        }
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
    
        writer.WriteStartObject();

        // Запись свойств в формате JSON
        writer.WriteString("coinsCount", value.ToString());
        

        // Конец записи объекта JSON
        writer.WriteEndObject();
    }
    
}