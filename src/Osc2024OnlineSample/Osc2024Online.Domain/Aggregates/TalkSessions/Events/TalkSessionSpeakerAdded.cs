using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Events;

public record TalkSessionSpeakerAdded(TalkSpeaker Speaker)
    : IEventPayload<TalkSession, TalkSessionSpeakerAdded>
{
    public static TalkSession OnEvent(
        TalkSession aggregatePayload,
        Event<TalkSessionSpeakerAdded> ev) =>
        aggregatePayload with { Speakers = [.. aggregatePayload.Speakers, ev.Payload.Speaker] };
}
