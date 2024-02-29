using System.ComponentModel.DataAnnotations;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;

public record TalkName(
    [property: MaxLength(100)]
    [property: Required]
    string Value)
{
    public static TalkName Empty => new(string.Empty);
}
