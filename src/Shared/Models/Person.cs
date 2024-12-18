using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    /// <summary>
    /// See <see href="https://web.archive.org/web/20241113211619/https://swapi.dev/documentation#people"/>.
    /// This record is annotated for both JSON deserialization and EF Core code-first context.
    /// </summary>
    public record Person(
        [property: Key]
        [property: JsonIgnore()]
        int Id,

        [property: JsonPropertyName("name")]
        string Name,

        [property: JsonPropertyName("birth_year")]
        string BirthYear,

        [property: JsonPropertyName("eye_color")]
        string EyeColor,

        [property: JsonPropertyName("gender")]
        string Gender,

        [property: JsonPropertyName("hair_color")]
        string HairColor,

        [property: JsonPropertyName("height")]
        uint Height,

        [property: JsonPropertyName("mass")]
        uint Mass,

        [property: JsonPropertyName("skin_color")]
        string SkinColor,

        [property: JsonPropertyName("homeworld")]
        string Homeworld,

        [property: JsonPropertyName("films")]
        string[] Films,

        [property: JsonPropertyName("species")]
        string[] Species,

        [property: JsonPropertyName("starships")]
        string[] Starships,

        [property: JsonPropertyName("vehicles")]
        string[] Vehicles,

        [property: JsonPropertyName("url")]
        string Url,

        [property: JsonPropertyName("created")]
        DateTime Created,

        [property: JsonPropertyName("edited")]
        DateTime Edited
    );
}