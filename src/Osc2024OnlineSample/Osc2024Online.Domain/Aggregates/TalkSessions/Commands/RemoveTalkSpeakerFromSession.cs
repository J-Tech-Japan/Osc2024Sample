using Osc2024Online.Domain.Aggregates.TalkSessions.Events;
using Sekiban.Core.Command;
using Sekiban.Core.Events;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Commands;

public record RemoveTalkSpeakerFromSession(Guid TalkSessionId, Guid TalkSpeakerId, string Note) : ICommand<TalkSession>
{
    public Guid GetAggregateId() => TalkSessionId;
    public class Handler : ICommandHandler<TalkSession, RemoveTalkSpeakerFromSession>
    {
        public IEnumerable<IEventPayloadApplicableTo<TalkSession>> HandleCommand(
            RemoveTalkSpeakerFromSession command,
            ICommandContext<TalkSession> context)
        {
            if (context.GetState().Payload.Speakers.Any(m => m.SpeakerId == command.TalkSpeakerId))
            {
                yield return new TalkSessionSpeakerDeleted(command.TalkSpeakerId, command.Note);
            }
        }
    }
}