using Osc2024Online.Domain;
using Osc2024Online.Domain.Aggregates.Conferences;
using Osc2024Online.Domain.Aggregates.Conferences.Commands;
using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Sekiban.Testing.SingleProjections;
namespace Osc2024Online.Test.AggregateTests;

public class ConferenceSpec : AggregateTest<Conference, OscDependencyDefinition>
{
    [Fact]
    public void CreateConferenceSpec()
    {
        WhenCommand(
            new CreateOneDayConference(
                new DateTime(2024, 3, 1),
                ConferenceLocationValue.Online,
                "Osc2024"));
        ThenPayloadIs(
            new Conference(
                new ConferenceName("Osc2024"),
                new ConferenceDates.OneDay(new DateTime(2024, 3, 1)),
                ConferenceLocation.FromValue(ConferenceLocationValue.Online)));
    }
    [Fact]
    public void CreateTwoDayConferenceSpec()
    {
        WhenCommand(
            new CreateTwoDayConference(
                new DateTime(2024, 3, 1),
                ConferenceLocationValue.Online,
                "Osc2024"));
        ThenPayloadIs(
            new Conference(
                new ConferenceName("Osc2024"),
                new ConferenceDates.MultiDays(new DateTime(2024, 3, 1), new DateTime(2024, 3, 2)),
                ConferenceLocation.FromValue(ConferenceLocationValue.Online)));
    }
}
