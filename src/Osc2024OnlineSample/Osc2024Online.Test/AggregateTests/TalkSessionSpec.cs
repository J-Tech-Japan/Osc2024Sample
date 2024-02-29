using Osc2024Online.Domain;
using Osc2024Online.Domain.Aggregates.Conferences.Commands;
using Osc2024Online.Domain.Aggregates.Conferences.ValueObjects;
using Osc2024Online.Domain.Aggregates.TalkSessions;
using Osc2024Online.Domain.Aggregates.TalkSessions.Commands;
using Osc2024Online.Domain.Aggregates.TalkSessions.ValueObjects;
using Sekiban.Testing.SingleProjections;
using System.Collections.Immutable;
namespace Osc2024Online.Test.AggregateTests;

public class TalkSessionSpec : AggregateTest<TalkSession, OscDependencyDefinition>
{
    [Fact]
    public void CreateTalkSessionSpec()
    {
        var conferenceId = GivenEnvironmentCommand(
            new CreateConference(
                new ConferenceId(Guid.NewGuid()),
                new ConferenceName("Osc2024"),
                new ConferenceDates.OneDay(new DateTime(2024, 3, 1)),
                ConferenceLocation.FromValue(ConferenceLocationValue.Online)));
        WhenCommand(new CreateTalkSession(new ConferenceId(conferenceId), new TalkName("Talk1"), new TalkDescription("Description1")));
        ThenPayloadIs(
            new TalkSession(
                new ConferenceId(conferenceId),
                new TalkName("Talk1"),
                new TalkDescription("Description1"),
                ImmutableList<TalkSpeaker>.Empty));
    }
    [Fact]
    public void AddSpeakerSpec()
    {
        var conferenceId = GivenEnvironmentCommand(
            new CreateConference(
                new ConferenceId(Guid.NewGuid()),
                new ConferenceName("Osc2024"),
                new ConferenceDates.OneDay(new DateTime(2024, 3, 1)),
                ConferenceLocation.FromValue(ConferenceLocationValue.Online)));
        GivenCommand(new CreateTalkSession(new ConferenceId(conferenceId), new TalkName("Talk1"), new TalkDescription("Description1")));
        var speaker = new TalkSpeaker(Guid.NewGuid(), "Speaker1", "スピーカーイチ", "CTO");
        WhenCommand(new AddTalkSpeakerForSession(GetAggregateId(), speaker));
        ThenPayloadIs(
            new TalkSession(
                new ConferenceId(conferenceId),
                new TalkName("Talk1"),
                new TalkDescription("Description1"),
                [speaker]));
    }

    [Fact]
    public void AddSecondSpeakerSpec()
    {
        var conferenceId = GivenEnvironmentCommand(
            new CreateConference(
                new ConferenceId(Guid.NewGuid()),
                new ConferenceName("Osc2024"),
                new ConferenceDates.OneDay(new DateTime(2024, 3, 1)),
                ConferenceLocation.FromValue(ConferenceLocationValue.Online)));
        GivenCommand(new CreateTalkSession(new ConferenceId(conferenceId), new TalkName("Talk1"), new TalkDescription("Description1")));
        var speaker = new TalkSpeaker(Guid.NewGuid(), "Speaker1", "スピーカーイチ", "CTO");
        GivenCommand(new AddTalkSpeakerForSession(GetAggregateId(), speaker));

        var speaker2 = new TalkSpeaker(Guid.NewGuid(), "Speaker2", "スピーカーニ", "マネージャ");
        WhenCommand(new AddTalkSpeakerForSession(GetAggregateId(), speaker2));

        ThenPayloadIs(
            new TalkSession(
                new ConferenceId(conferenceId),
                new TalkName("Talk1"),
                new TalkDescription("Description1"),
                [speaker, speaker2]));
    }

    [Fact]
    public void UpdateFirstSpeakerSpec()
    {
        var conferenceId = GivenEnvironmentCommand(
            new CreateConference(
                new ConferenceId(Guid.NewGuid()),
                new ConferenceName("Osc2024"),
                new ConferenceDates.OneDay(new DateTime(2024, 3, 1)),
                ConferenceLocation.FromValue(ConferenceLocationValue.Online)));
        GivenCommand(new CreateTalkSession(new ConferenceId(conferenceId), new TalkName("Talk1"), new TalkDescription("Description1")));
        var speaker = new TalkSpeaker(Guid.NewGuid(), "Speaker1", "スピーカーイチ", "CTO");
        GivenCommand(new AddTalkSpeakerForSession(GetAggregateId(), speaker));

        var speaker2 = new TalkSpeaker(Guid.NewGuid(), "Speaker2", "スピーカーニ", "マネージャ");
        GivenCommand(new AddTalkSpeakerForSession(GetAggregateId(), speaker2));

        var speakerEdited = speaker with { Name = "Speaker1Edited" };
        WhenCommand(new UpdateTalkSpeakerForSession(GetAggregateId(), speakerEdited, "made mistake"));

        ThenPayloadIs(
            new TalkSession(
                new ConferenceId(conferenceId),
                new TalkName("Talk1"),
                new TalkDescription("Description1"),
                [speakerEdited, speaker2]));
    }


    [Fact]
    public void RemoveFirstSpeakerSpec()
    {
        var conferenceId = GivenEnvironmentCommand(
            new CreateConference(
                new ConferenceId(Guid.NewGuid()),
                new ConferenceName("Osc2024"),
                new ConferenceDates.OneDay(new DateTime(2024, 3, 1)),
                ConferenceLocation.FromValue(ConferenceLocationValue.Online)));
        GivenCommand(new CreateTalkSession(new ConferenceId(conferenceId), new TalkName("Talk1"), new TalkDescription("Description1")));
        var speaker = new TalkSpeaker(Guid.NewGuid(), "Speaker1", "スピーカーイチ", "CTO");
        GivenCommand(new AddTalkSpeakerForSession(GetAggregateId(), speaker));

        var speaker2 = new TalkSpeaker(Guid.NewGuid(), "Speaker2", "スピーカーニ", "マネージャ");
        GivenCommand(new AddTalkSpeakerForSession(GetAggregateId(), speaker2));

        WhenCommand(new RemoveTalkSpeakerFromSession(GetAggregateId(), speaker.SpeakerId, "made mistake"));

        ThenPayloadIs(
            new TalkSession(
                new ConferenceId(conferenceId),
                new TalkName("Talk1"),
                new TalkDescription("Description1"),
                [speaker2]));
    }

    [Fact]
    public void CanNotCreateTalkSessionWithoutConferenceSpec()
    {
        var conferenceId = Guid.NewGuid();
        WhenCommand(new CreateTalkSession(new ConferenceId(conferenceId), new TalkName("Talk1"), new TalkDescription("Description1")));
        ThenGetLatestEvents(Assert.Empty);
    }
}
