using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Onvif.Core.Client.Event;

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[ServiceContractAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", ConfigurationName = "Event")]
public interface Event
{
    [OperationContractAttribute(Action = "http://www.onvif.org/ver10/events/wsdl/EventPortType/GetServiceCapabilities", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    [ServiceKnownTypeAttribute(typeof(Capabilities))]
    [return: MessageParameterAttribute(Name = "Capabilities")]
    Task<Capabilities> GetServiceCapabilitiesAsync();

    [OperationContractAttribute(Action = "http://www.onvif.org/ver10/events/wsdl/EventPortType/GetEventProperties", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task<GetEventPropertiesResponse> GetEventPropertiesAsync(GetEventPropertiesRequest request);

    [OperationContractAttribute(Action = "http://www.onvif.org/ver10/events/wsdl/EventPortType/CreatePullPointSubscription", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task<CreatePullPointSubscriptionResponse> CreatePullPointSubscriptionAsync(CreatePullPointSubscriptionRequest request);

    [OperationContractAttribute(Action = "http://www.onvif.org/ver10/events/wsdl/PullPointSubscription/PullMessages", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task<PullMessagesResponse> PullMessagesAsync(PullMessagesRequest request);

    [OperationContractAttribute(Action = "http://www.onvif.org/ver10/events/wsdl/PullPointSubscription/GetMessages", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task<GetMessagesResponse> GetMessagesAsync(GetMessagesRequest request);

    [OperationContractAttribute(Action = "http://www.onvif.org/ver10/events/wsdl/PullPointSubscription/Seek", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task SeekAsync(System.DateTime UtcTime, bool Reverse);

    [OperationContractAttribute(Action = "http://www.onvif.org/ver10/events/wsdl/PullPointSubscription/SetSynchronizationPoint", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task SetSynchronizationPointAsync();

    [OperationContractAttribute(Action = "http://docs.oasis-open.org/wsn/bw-2/SubscriptionManager/RenewRequest", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task<RenewResponse> RenewAsync(RenewRequest request);

    [OperationContractAttribute(Action = "http://docs.oasis-open.org/wsn/bw-2/SubscriptionManager/UnsubscribeRequest", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task UnsubscribeAsync(UnsubscribeRequest request);

    [OperationContractAttribute(Action = "http://docs.oasis-open.org/wsn/bw-2/SubscriptionManager/PauseRequest", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task PauseAsync(PauseRequest request);

    [OperationContractAttribute(Action = "http://docs.oasis-open.org/wsn/bw-2/SubscriptionManager/ResumeRequest", ReplyAction = "*")]
    [XmlSerializerFormatAttribute(SupportFaults = true)]
    Task ResumeAsync(ResumeRequest request);
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
public interface EventChannel : Event, IClientChannel
{
}

[DebuggerStepThroughAttribute()]
[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
public partial class EventClient : ClientBase<Event>, Event
{
    internal EventClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
    {
    }

    public Task<Capabilities> GetServiceCapabilitiesAsync() => base.Channel.GetServiceCapabilitiesAsync();

    public Task<GetEventPropertiesResponse> GetEventPropertiesAsync(GetEventPropertiesRequest request) =>
        base.Channel.GetEventPropertiesAsync(request);

    public Task<GetEventPropertiesResponse> GetEventPropertiesAsync() =>
        base.Channel.GetEventPropertiesAsync(new GetEventPropertiesRequest());

    public Task<CreatePullPointSubscriptionResponse> CreatePullPointSubscriptionAsync(CreatePullPointSubscriptionRequest request) =>
        base.Channel.CreatePullPointSubscriptionAsync(request);

    public Task<PullMessagesResponse> PullMessagesAsync(PullMessagesRequest request) =>
        base.Channel.PullMessagesAsync(request);

    public Task<PullMessagesResponse> PullMessagesAsync(TimeSpan timeout, int messageLimit) =>
        base.Channel.PullMessagesAsync(new PullMessagesRequest(timeout, messageLimit));

    public Task<GetMessagesResponse> GetMessagesAsync(GetMessagesRequest request) => base.Channel.GetMessagesAsync(request);

    public Task<GetMessagesResponse> GetMessagesAsync(int messageLimit) =>
        base.Channel.GetMessagesAsync(new GetMessagesRequest(messageLimit));

    public Task SeekAsync(System.DateTime UtcTime, bool Reverse) => base.Channel.SeekAsync(UtcTime, Reverse);

    public Task SetSynchronizationPointAsync() => base.Channel.SetSynchronizationPointAsync();

    public Task<RenewResponse> RenewAsync(string TerminationTime) => base.Channel.RenewAsync(new RenewRequest(TerminationTime));

    public Task UnsubscribeAsync() => base.Channel.UnsubscribeAsync(new UnsubscribeRequest());

    public Task PauseAsync() => base.Channel.PauseAsync(new PauseRequest());

    public Task ResumeAsync() => base.Channel.ResumeAsync(new ResumeRequest());

    [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
    Task<RenewResponse> Event.RenewAsync(RenewRequest request) => base.Channel.RenewAsync(request);

    [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
    Task Event.UnsubscribeAsync(UnsubscribeRequest request) => base.Channel.UnsubscribeAsync(request);

    [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
    Task Event.PauseAsync(PauseRequest request) => base.Channel.PauseAsync(request);

    [EditorBrowsableAttribute(EditorBrowsableState.Advanced)]
    Task Event.ResumeAsync(ResumeRequest request) => base.Channel.ResumeAsync(request);

    public EventClient CreateSubscriptionManagerClient(EndpointReferenceType subscriptionReference)
    {
        ArgumentNullException.ThrowIfNull(subscriptionReference);
        if (string.IsNullOrWhiteSpace(subscriptionReference.Address))
        {
            throw new ArgumentException("The subscription reference must include an address.", nameof(subscriptionReference));
        }

        var client = new EventClient(ChannelFactory.Endpoint.Binding, new EndpointAddress(subscriptionReference.Address));
        client.ChannelFactory.Endpoint.EndpointBehaviors.Clear();
        foreach (var behavior in ChannelFactory.Endpoint.EndpointBehaviors)
        {
            client.ChannelFactory.Endpoint.EndpointBehaviors.Add(behavior);
        }
        return client;
    }

    public virtual Task OpenAsync() => Task.Factory.FromAsync(((ICommunicationObject)this).BeginOpen(null, null), new Action<IAsyncResult>(((ICommunicationObject)this).EndOpen));

    public virtual Task CloseAsync() => Task.Factory.FromAsync(((ICommunicationObject)this).BeginClose(null, null), new Action<IAsyncResult>(((ICommunicationObject)this).EndClose));
}
