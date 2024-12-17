using System.Text.Json.Serialization;

namespace Shared.Models
{
    public record People(
        [property: JsonPropertyName("count")]
        int Count,

        [property: JsonPropertyName("next")]
        string Next,

        [property: JsonPropertyName("previous")]
        string Previous,

        [property: JsonPropertyName("results")]
        Person[] Results
    );
}