using Osc2024Online.Domain.Aggregates.TalkSessions.Events;
using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Core.Command;
using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Commands;

public record AddTalkSpeakerForSession(Guid TalkSessionId, TalkSpeaker Speaker)
    : ICommandForExistingAggregate<TalkSession>
{
    public Guid GetAggregateId() => TalkSessionId;
    public class Handler : ICommandHandler<TalkSession, AddTalkSpeakerForSession>
    {
        public IEnumerable<IEventPayloadApplicableTo<TalkSession>> HandleCommand(
            AddTalkSpeakerForSession command,
            ICommandContext<TalkSession> context)
        {
            yield return new TalkSessionSpeakerAdded(command.Speaker);
        }
    }
}