using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Sekiban.Core.Aggregate;
namespace Osc2024Online.Domain.Aggregates.Conferences;

public record Conference(ConferenceName Name, ConferenceDates.IConferenceDates Dates, ConferenceLocation Location) : IAggregatePayload<Conference>
{
    public static Conference CreateInitialPayload(Conference? _) =>
        new(ConferenceName.Empty, ConferenceDates.OneDay.Empty, ConferenceLocation.Online);
}
