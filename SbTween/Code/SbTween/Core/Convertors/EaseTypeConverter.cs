#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SbTween;

public class EaseTypeConverter : JsonConverter<EaseType>
{
    public override EaseType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            long num = reader.GetInt64();
            return (EaseType)num;
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            string? str = reader.GetString();
            if (!string.IsNullOrEmpty(str) && Enum.TryParse<EaseType>(str, true, out var result))
	            return result;
        }

        return EaseType.Linear;
    }

    public override void Write(Utf8JsonWriter writer, EaseType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
