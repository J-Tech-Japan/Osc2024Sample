using Osc2024Online.Domain.Aggregates.Conferences;
using Osc2024Online.Domain.Aggregates.Conferences.Commands;
using Osc2024Online.Domain.Aggregates.TalkSessions;
using Osc2024Online.Domain.Aggregates.TalkSessions.Commands;
using Sekiban.Core.Dependency;
using System.Reflection;
namespace Osc2024Online.Domain;

public class OscDependencyDefinition : DomainDependencyDefinitionBase
{
    public override Assembly GetExecutingAssembly() => Assembly.GetExecutingAssembly();
    public override void Define()
    {
        AddAggregate<Conference>()
            .AddCommandHandler<CreateConference, CreateConference.Handler>()
            .AddCommandHandler<CreateOneDayConference, CreateOneDayConference.Handler>();

        AddAggregate<TalkSession>()
            .AddCommandHandler<CreateTalkSession, CreateTalkSession.Handler>()
            .AddCommandHandler<AddTalkSpeakerForSession, AddTalkSpeakerForSession.Handler>()
            .AddCommandHandler<RemoveTalkSpeakerFromSession, RemoveTalkSpeakerFromSession.Handler>()
            .AddCommandHandler<UpdateTalkSpeakerForSession, UpdateTalkSpeakerForSession.Handler>();
    }
}
