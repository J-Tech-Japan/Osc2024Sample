using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Core.Aggregate;
using System.Collections.Immutable;
namespace Osc2024Online.Domain.Aggregates.TalkSessions;

public record TalkSession(ConferenceId ConferenceId, TalkName Name, TalkDescription Description, ImmutableList<TalkSpeaker> Speakers)
    : IAggregatePayload<TalkSession>
{
    public static TalkSession CreateInitialPayload(TalkSession? _) => new(
        ConferenceId.Empty,
        TalkName.Empty,
        TalkDescription.Empty,
        ImmutableList<TalkSpeaker>.Empty);
}
