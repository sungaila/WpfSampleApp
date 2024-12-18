using System.Text.Json.Serialization;

namespace Shared.Models
{
    /// <summary>
    /// See <see href="https://web.archive.org/web/20230124201909/https://swapi.dev/api/people/?format=json"/>.
    /// Represents the JSON returned from swapi.dev for JSON deserialization.
    /// </summary>
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