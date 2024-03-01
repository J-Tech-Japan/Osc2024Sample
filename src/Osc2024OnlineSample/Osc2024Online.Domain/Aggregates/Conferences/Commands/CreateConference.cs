using Osc2024Online.Domain.Aggregates.Conferences.Events;
using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Sekiban.Core.Command;
using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.Conferences.Commands;

public record CreateConference(
    ConferenceId Id,
    ConferenceName Name,
    ConferenceDates.IConferenceDates Dates,
    ConferenceLocation Location)
    : ICommand<Conference>
{
    public Guid GetAggregateId() => Id.Value;
    public class Handler : ICommandHandler<Conference, CreateConference>
    {
        public IEnumerable<IEventPayloadApplicableTo<Conference>> HandleCommand(
            CreateConference command,
            ICommandContext<Conference> context)
        {
            yield return new ConferenceCreated(command.Name, command.Dates, command.Location);
        }
    }
}
