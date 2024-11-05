using System.Reflection;
using BlockChain.Domain.Enums;
using BlockChain.Utils;

namespace BlockChain.Utils;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CommandTypeConverter : JsonConverter<CommandType>
{
    public override CommandType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return (CommandType)reader.GetInt32();
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            return Enum.Parse<CommandType>(reader.GetString(), true);
        }
        else
        {
            throw new JsonException($"Cannot convert JSON to {nameof(CommandType)}");
        }
    }

    public override void Write(Utf8JsonWriter writer, CommandType value, JsonSerializerOptions options)
    {
        var memberInfo = value.GetType().GetMember(value.ToString());
        var jsonPropertyAttribute = memberInfo[0].GetCustomAttribute<JsonPropertyNameAttribute>();
        writer.WriteStringValue(jsonPropertyAttribute?.Name ?? value.ToString());
    }
}