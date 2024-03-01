using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Sekiban.Core.Command;
namespace Osc2024Online.Domain.Aggregates.Conferences.Commands;

public record CreateTwoDayConference(
    DateTime FirstDate,
    ConferenceLocationValue Location,
    string ConferenceName) : ICommandConverter<Conference>
{
    public Guid GetAggregateId() => Guid.NewGuid();
    public class Handler : ICommandConverterHandler<Conference, CreateTwoDayConference>
    {
        public ICommand<Conference> ConvertCommand(CreateTwoDayConference command) =>
            new CreateConference(
                new ConferenceId(command.GetAggregateId()),
                new ConferenceName(command.ConferenceName),
                new ConferenceDates.MultiDays(command.FirstDate, command.FirstDate.AddDays(1)),
                ConferenceLocation.FromValue(command.Location));
    }
}