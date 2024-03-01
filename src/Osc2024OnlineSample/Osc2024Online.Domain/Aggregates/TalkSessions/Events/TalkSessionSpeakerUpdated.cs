using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Events;

public record TalkSessionSpeakerUpdated(TalkSpeaker Speaker, string Note)
    : IEventPayload<TalkSession, TalkSessionSpeakerUpdated>
{
    public static TalkSession OnEvent(
        TalkSession aggregatePayload,
        Event<TalkSessionSpeakerUpdated> ev) => aggregatePayload with
    {
        Speakers = aggregatePayload.Speakers.Replace(
            aggregatePayload.Speakers.First(s => s.SpeakerId == ev.Payload.Speaker.SpeakerId),
            ev.Payload.Speaker)
    };
}
