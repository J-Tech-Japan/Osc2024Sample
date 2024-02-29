using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Sekiban.Core.Command;
namespace Osc2024Online.Domain.Aggregates.Conferences.Commands;

public record CreateOneDayConference(DateTime Date, ConferenceLocationValue Location, string ConferenceName) : ICommandConverter<Conference>
{
    public Guid GetAggregateId() => Guid.NewGuid();
    public class Handler : ICommandConverterHandler<Conference, CreateOneDayConference>
    {
        public ICommand<Conference> ConvertCommand(CreateOneDayConference command) => new CreateConference(
            new ConferenceId(command.GetAggregateId()),
            new ConferenceName(command.ConferenceName),
            new ConferenceDates.OneDay(command.Date),
            ConferenceLocation.FromValue(command.Location));
    }
}
