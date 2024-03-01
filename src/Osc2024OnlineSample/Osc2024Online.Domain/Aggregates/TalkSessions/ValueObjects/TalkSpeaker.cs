using System.ComponentModel.DataAnnotations;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;

public record TalkSpeaker(
    Guid SpeakerId,
    [property: Required]
    [property: MaxLength(50)]
    string Name,
    [property: Required]
    [property: MaxLength(50)]
    string Kana,
    [property: MaxLength(50)]
    string Title)
{
    public static TalkSpeaker CreateInitialPayload(TalkSpeaker? _) => new(
        Guid.Empty,
        string.Empty,
        string.Empty,
        string.Empty);
}
