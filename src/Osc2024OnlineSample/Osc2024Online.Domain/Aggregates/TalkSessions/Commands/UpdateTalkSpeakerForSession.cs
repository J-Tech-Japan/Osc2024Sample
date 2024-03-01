using Osc2024Online.Domain.Aggregates.TalkSessions.Events;
using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Core.Command;
using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Commands;

public record UpdateTalkSpeakerForSession(Guid TalkSessionId, TalkSpeaker Speaker, string Note)
    : ICommandForExistingAggregate<TalkSession>
{
    public Guid GetAggregateId() => TalkSessionId;
    public class Handler : ICommandHandler<TalkSession, UpdateTalkSpeakerForSession>
    {
        public IEnumerable<IEventPayloadApplicableTo<TalkSession>> HandleCommand(
            UpdateTalkSpeakerForSession command,
            ICommandContext<TalkSession> context)
        {
            yield return new TalkSessionSpeakerUpdated(command.Speaker, command.Note);
        }
    }
}
