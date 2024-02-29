using System.ComponentModel.DataAnnotations;
namespace Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;

public record ConferenceName(
    [property: Required]
    [property: MaxLength(100)]
    string Value)
{
    public static ConferenceName Empty => new(string.Empty);
}
