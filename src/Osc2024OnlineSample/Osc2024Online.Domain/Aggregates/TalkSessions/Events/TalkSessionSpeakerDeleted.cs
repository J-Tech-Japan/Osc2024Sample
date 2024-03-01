using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Events;

public record TalkSessionSpeakerDeleted(Guid SpeakerId, string Note)
    : IEventPayload<TalkSession, TalkSessionSpeakerDeleted>
{
    public static TalkSession OnEvent(
        TalkSession aggregatePayload,
        Event<TalkSessionSpeakerDeleted> ev) => aggregatePayload with
    {
        Speakers = aggregatePayload.Speakers.RemoveAll(s => s.SpeakerId == ev.Payload.SpeakerId)
    };
}
