using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.Conferences.Events;

public record ConferenceCreated(
    ConferenceName Name,
    ConferenceDates.IConferenceDates Dates,
    ConferenceLocation Location)
    : IEventPayload<Conference, ConferenceCreated>
{
    public static Conference OnEvent(Conference aggregatePayload, Event<ConferenceCreated> ev) =>
        new(ev.Payload.Name, ev.Payload.Dates, ev.Payload.Location);
}
