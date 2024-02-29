namespace Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;

public record ConferenceId(Guid Value)
{
    public static ConferenceId Empty => new(Guid.Empty);
}
