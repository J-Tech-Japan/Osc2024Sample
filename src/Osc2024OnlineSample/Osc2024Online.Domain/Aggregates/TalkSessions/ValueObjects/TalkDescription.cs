using System.ComponentModel.DataAnnotations;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;

public record TalkDescription(
    [property: MaxLength(1000)]
    [property: Required]
    string Value)
{
    public static TalkDescription Empty => new(string.Empty);
}
