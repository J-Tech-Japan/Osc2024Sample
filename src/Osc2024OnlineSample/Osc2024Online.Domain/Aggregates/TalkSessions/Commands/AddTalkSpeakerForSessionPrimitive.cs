using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Core.Command;
namespace Osc2024Online.Domain.Aggregates.TalkSessions.Commands;

public record AddTalkSpeakerForSessionPrimitive(
    Guid TalkSessionId,
    string SpeakerName,
    string SpeakerKana,
    string SpeakerTitle) : ICommandConverter<TalkSession>
{
    public Guid GetAggregateId() => TalkSessionId;

    public class Handler : ICommandConverterHandler<TalkSession, AddTalkSpeakerForSessionPrimitive>
    {
        public ICommand<TalkSession> ConvertCommand(AddTalkSpeakerForSessionPrimitive command) =>
            new AddTalkSpeakerForSession(
                command.TalkSessionId,
                new TalkSpeaker(
                    Guid.NewGuid(),
                    command.SpeakerName,
                    command.SpeakerKana,
                    command.SpeakerTitle));
    }
}