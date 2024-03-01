using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Events;

public record TalkSessionCreated(
    ConferenceId ConferenceId,
    TalkName Name,
    TalkDescription Description)
    : IEventPayload<TalkSession, TalkSessionCreated>
{
    public static TalkSession OnEvent(TalkSession aggregatePayload, Event<TalkSessionCreated> ev) =>
        aggregatePayload with
        {
            ConferenceId = ev.Payload.ConferenceId, Name = ev.Payload.Name,
            Description = ev.Payload.Description
        };
}
