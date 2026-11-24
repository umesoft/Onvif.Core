using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Onvif.Core.Client.Event;

/// <remarks/>
[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[XmlTypeAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl")]
public partial class Capabilities
{
    [XmlAttributeAttribute()]
    public bool WSSubscriptionPolicySupport { get; set; }

    [XmlIgnoreAttribute()]
    public bool WSSubscriptionPolicySupportSpecified { get; set; }

    [XmlAttributeAttribute()]
    public bool WSPullPointSupport { get; set; }

    [XmlIgnoreAttribute()]
    public bool WSPullPointSupportSpecified { get; set; }

    [XmlAttributeAttribute()]
    public bool WSPausableSubscriptionManagerInterfaceSupport { get; set; }

    [XmlIgnoreAttribute()]
    public bool WSPausableSubscriptionManagerInterfaceSupportSpecified { get; set; }

    [XmlAttributeAttribute()]
    public int MaxNotificationProducers { get; set; }

    [XmlIgnoreAttribute()]
    public bool MaxNotificationProducersSpecified { get; set; }

    [XmlAttributeAttribute()]
    public int MaxPullPoints { get; set; }

    [XmlIgnoreAttribute()]
    public bool MaxPullPointsSpecified { get; set; }

    [XmlAttributeAttribute()]
    public bool PersistentNotificationStorage { get; set; }

    [XmlIgnoreAttribute()]
    public bool PersistentNotificationStorageSpecified { get; set; }

    [XmlAttributeAttribute()]
    public string EventBrokerProtocols { get; set; }

    [XmlAttributeAttribute()]
    public int MaxEventBrokers { get; set; }

    [XmlIgnoreAttribute()]
    public bool MaxEventBrokersSpecified { get; set; }

    [XmlAttributeAttribute()]
    public bool MetadataOverMQTT { get; set; }

    [XmlIgnoreAttribute()]
    public bool MetadataOverMQTTSpecified { get; set; }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2")]
public partial class FilterType
{
    [XmlAnyElementAttribute()]
    public XElement[] Any { get; set; }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
public partial class EndpointReferenceType
{
    [XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing", Order = 0)]
    public string Address { get; set; }

    [XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing", Order = 1)]
    public ReferenceParametersType ReferenceParameters { get; set; }

    [XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing", Order = 2)]
    public MetadataType Metadata { get; set; }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
public partial class ReferenceParametersType
{
    [XmlAnyElementAttribute()]
    public XElement[] Any { get; set; }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[XmlTypeAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
public partial class MetadataType
{
    [XmlAnyElementAttribute()]
    public XElement[] Any { get; set; }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2")]
public partial class TopicExpressionType
{
    [XmlAttributeAttribute()]
    public string Dialect { get; set; }

    [XmlTextAttribute()]
    public string Value { get; set; }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2")]
public partial class NotificationMessageHolderType
{
    [XmlAnyElementAttribute()]
    public XElement[] Any { get; set; }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2")]
public partial class NotificationMessage
{
    [XmlElementAttribute(Namespace = "http://www.w3.org/2005/08/addressing", Order = 0)]
    public EndpointReferenceType ProducerReference { get; set; }

    [XmlElementAttribute(Order = 1)]
    public TopicExpressionType Topic { get; set; }

    [XmlElementAttribute(Order = 2)]
    public NotificationMessageHolderType Message { get; set; }

    [XmlAnyElementAttribute(Order = 3)]
    public XElement[] Any { get; set; }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "GetEventProperties", WrapperNamespace = "http://www.onvif.org/ver10/events/wsdl", IsWrapped = true)]
public partial class GetEventPropertiesRequest
{
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "GetEventPropertiesResponse", WrapperNamespace = "http://www.onvif.org/ver10/events/wsdl", IsWrapped = true)]
public partial class GetEventPropertiesResponse
{
    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 0)]
    [XmlElementAttribute("TopicNamespaceLocation")]
    public string[] TopicNamespaceLocation;

    [MessageBodyMemberAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", Order = 1)]
    [XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2")]
    public bool FixedTopicSet;

    [MessageBodyMemberAttribute(Namespace = "http://docs.oasis-open.org/wsn/t-1", Order = 2)]
    [XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wsn/t-1")]
    public XElement TopicSet;

    [MessageBodyMemberAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", Order = 3)]
    [XmlElementAttribute("TopicExpressionDialect", Namespace = "http://docs.oasis-open.org/wsn/b-2")]
    public string[] TopicExpressionDialect;

    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 4)]
    [XmlElementAttribute("MessageContentFilterDialect")]
    public string[] MessageContentFilterDialect;

    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 5)]
    [XmlElementAttribute("ProducerPropertiesFilterDialect")]
    public string[] ProducerPropertiesFilterDialect;

    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 6)]
    [XmlElementAttribute("MessageContentSchemaLocation")]
    public string[] MessageContentSchemaLocation;
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "CreatePullPointSubscription", WrapperNamespace = "http://www.onvif.org/ver10/events/wsdl", IsWrapped = true)]
public partial class CreatePullPointSubscriptionRequest
{
    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 0)]
    public FilterType Filter;

    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 1)]
    public string InitialTerminationTime;

    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 2)]
    public XElement SubscriptionPolicy;
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "CreatePullPointSubscriptionResponse", WrapperNamespace = "http://www.onvif.org/ver10/events/wsdl", IsWrapped = true)]
public partial class CreatePullPointSubscriptionResponse
{
    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 0)]
    public EndpointReferenceType SubscriptionReference;

    [MessageBodyMemberAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", Order = 1)]
    [XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", DataType = "dateTime")]
    public System.DateTime CurrentTime;

    [MessageBodyMemberAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", Order = 2)]
    [XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", DataType = "dateTime")]
    public System.DateTime TerminationTime;
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "PullMessages", WrapperNamespace = "http://www.onvif.org/ver10/events/wsdl", IsWrapped = true)]
public partial class PullMessagesRequest
{
    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 0, Name = "Timeout")]
    [XmlElementAttribute("Timeout")]
    public string TimeoutXml
    {
        get => XmlConvert.ToString(Timeout);
        set => Timeout = XmlConvert.ToTimeSpan(value);
    }

    [XmlIgnoreAttribute()]
    public TimeSpan Timeout { get; set; }

    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 1)]
    public int MessageLimit;

    public PullMessagesRequest()
    {
    }

    public PullMessagesRequest(TimeSpan timeout, int messageLimit)
    {
        Timeout = timeout;
        MessageLimit = messageLimit;
    }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "PullMessagesResponse", WrapperNamespace = "http://www.onvif.org/ver10/events/wsdl", IsWrapped = true)]
public partial class PullMessagesResponse
{
    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 0)]
    [XmlElementAttribute(DataType = "dateTime")]
    public System.DateTime CurrentTime;

    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 1)]
    [XmlElementAttribute(DataType = "dateTime")]
    public System.DateTime TerminationTime;

    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 2)]
    [XmlElementAttribute("NotificationMessage", Namespace = "http://docs.oasis-open.org/wsn/b-2")]
    public NotificationMessage[] NotificationMessage;
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "GetMessages", WrapperNamespace = "http://www.onvif.org/ver10/events/wsdl", IsWrapped = true)]
public partial class GetMessagesRequest
{
    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 0)]
    public int MessageLimit;

    public GetMessagesRequest()
    {
    }

    public GetMessagesRequest(int messageLimit)
    {
        MessageLimit = messageLimit;
    }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "GetMessagesResponse", WrapperNamespace = "http://www.onvif.org/ver10/events/wsdl", IsWrapped = true)]
public partial class GetMessagesResponse
{
    [MessageBodyMemberAttribute(Namespace = "http://www.onvif.org/ver10/events/wsdl", Order = 0)]
    [XmlElementAttribute("NotificationMessage", Namespace = "http://docs.oasis-open.org/wsn/b-2")]
    public NotificationMessage[] NotificationMessage;
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "Renew", WrapperNamespace = "http://docs.oasis-open.org/wsn/b-2", IsWrapped = true)]
public partial class RenewRequest
{
    [MessageBodyMemberAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", Order = 0)]
    public string TerminationTime;

    public RenewRequest()
    {
    }

    public RenewRequest(string terminationTime)
    {
        TerminationTime = terminationTime;
    }
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "Unsubscribe", WrapperNamespace = "http://docs.oasis-open.org/wsn/b-2", IsWrapped = true)]
public partial class UnsubscribeRequest
{
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "Pause", WrapperNamespace = "http://docs.oasis-open.org/wsn/b-2", IsWrapped = true)]
public partial class PauseRequest
{
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "Resume", WrapperNamespace = "http://docs.oasis-open.org/wsn/b-2", IsWrapped = true)]
public partial class ResumeRequest
{
}

[GeneratedCodeAttribute("dotnet-svcutil", "1.0.3")]
[DebuggerStepThroughAttribute()]
[MessageContractAttribute(WrapperName = "RenewResponse", WrapperNamespace = "http://docs.oasis-open.org/wsn/b-2", IsWrapped = true)]
public partial class RenewResponse
{
    [MessageBodyMemberAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", Order = 0)]
    [XmlElementAttribute(DataType = "dateTime")]
    public System.DateTime CurrentTime;

    [MessageBodyMemberAttribute(Namespace = "http://docs.oasis-open.org/wsn/b-2", Order = 1)]
    [XmlElementAttribute(DataType = "dateTime")]
    public System.DateTime TerminationTime;
}
