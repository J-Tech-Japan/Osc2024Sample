using Osc2024Online.Domain.Aggregates.Conferences;
using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Osc2024Online.Domain.Aggregates.TalkSessions.Events;
using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Core.Command;
using Sekiban.Core.Events;
using Sekiban.Core.Query.SingleProjections;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Commands;

public record CreateTalkSession(ConferenceId ConferenceId, TalkName Name, TalkDescription Description) : ICommand<TalkSession>
{
    public Guid GetAggregateId() => Guid.NewGuid();
    public class Handler(IAggregateLoader aggregateLoader) : ICommandHandlerAsync<TalkSession, CreateTalkSession>
    {
        public async IAsyncEnumerable<IEventPayloadApplicableTo<TalkSession>> HandleCommandAsync(
            CreateTalkSession command,
            ICommandContext<TalkSession> context)
        {
            var conference = await aggregateLoader.AsDefaultStateAsync<Conference>(command.ConferenceId.Value);
            if (conference is not null)
            {
                yield return new TalkSessionCreated(command.ConferenceId, command.Name, command.Description);
            }
        }
    }
}
