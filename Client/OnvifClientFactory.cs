using Onvif.Core.Client.Common;
using Onvif.Core.Client.Device;
using Onvif.Core.Client.Event;
using Onvif.Core.Client.Imaging;
using Onvif.Core.Client.Media;
using Onvif.Core.Client.Ptz;
using Onvif.Core.Client.Security;

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Onvif.Core.Client;

public static class OnvifClientFactory
{
	static Binding CreateBinding()
	{
		var binding = new CustomBinding();
		var textBindingElement = new TextMessageEncodingBindingElement
		{
			MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
		};
		var httpBindingElement = new HttpTransportBindingElement
		{
			AllowCookies = true,
			MaxBufferSize = int.MaxValue,
			MaxReceivedMessageSize = int.MaxValue
		};

		binding.Elements.Add(textBindingElement);
		binding.Elements.Add(httpBindingElement);

		return binding;
	}

	public static async Task<DeviceClient> CreateDeviceClientAsync(Uri uri, string username, string password)
	{
		var binding = CreateBinding();
		var endpoint = new EndpointAddress(uri);
		var device = new DeviceClient(binding, endpoint);
		var time_shift = await GetDeviceTimeShift(device).ConfigureAwait(false);

		device = new DeviceClient(binding, endpoint);
		device.ChannelFactory.Endpoint.EndpointBehaviors.Clear();
		device.ChannelFactory.Endpoint.EndpointBehaviors.Add(new SoapSecurityHeaderBehavior(username, password, time_shift));

		// Connectivity Test
		await device.OpenAsync().ConfigureAwait(false);

		return device;
	}

	public static async Task<DeviceClient> CreatePreAuthDeviceClientAsync(Uri uri)
	{
		var binding = CreateBinding();
		var endpoint = new EndpointAddress(uri);
		var device = new DeviceClient(binding, endpoint);
		device.ChannelFactory.Endpoint.EndpointBehaviors.Clear();

		// Connectivity Test
		await device.OpenAsync().ConfigureAwait(false);

		return device;
	}

	public static async Task<MediaClient> CreateMediaClientAsync(string xAddress, string username, string password)
	{
		var binding = CreateBinding();
		var device = await CreateDeviceClientAsync(new Uri(xAddress), username, password).ConfigureAwait(false);
		var caps = await device.GetCapabilitiesAsync([CapabilityCategory.Media]).ConfigureAwait(false);
		var media = new MediaClient(binding, new EndpointAddress(new Uri(caps.Capabilities.Media.XAddr)));

		var time_shift = await GetDeviceTimeShift(device).ConfigureAwait(false);
		media.ChannelFactory.Endpoint.EndpointBehaviors.Clear();
		media.ChannelFactory.Endpoint.EndpointBehaviors.Add(new SoapSecurityHeaderBehavior(username, password, time_shift));

		// Connectivity Test
		await media.OpenAsync().ConfigureAwait(false);

		return media;
	}

	public static async Task<PTZClient> CreatePTZClientAsync(string xAddress, string username, string password)
	{
		var binding = CreateBinding();
		var device = await CreateDeviceClientAsync(new Uri(xAddress), username, password).ConfigureAwait(false);
		var caps = await device.GetCapabilitiesAsync([CapabilityCategory.PTZ]).ConfigureAwait(false);
		var ptz = new PTZClient(binding, new EndpointAddress(new Uri(caps.Capabilities.PTZ.XAddr)));

		var time_shift = await GetDeviceTimeShift(device).ConfigureAwait(false);
		ptz.ChannelFactory.Endpoint.EndpointBehaviors.Clear();
		ptz.ChannelFactory.Endpoint.EndpointBehaviors.Add(new SoapSecurityHeaderBehavior(username, password, time_shift));

		// Connectivity Test
		await ptz.OpenAsync().ConfigureAwait(false);

		return ptz;
	}

	public static async Task<ImagingClient> CreateImagingClientAsync(string xAddress, string username, string password)
	{
		var binding = CreateBinding();
		var device = await CreateDeviceClientAsync(new Uri(xAddress), username, password).ConfigureAwait(false);
		var caps = await device.GetCapabilitiesAsync([CapabilityCategory.Imaging]).ConfigureAwait(false);
		var imaging = new ImagingClient(binding, new EndpointAddress(new Uri(caps.Capabilities.Imaging.XAddr)));

		var time_shift = await GetDeviceTimeShift(device).ConfigureAwait(false);
		imaging.ChannelFactory.Endpoint.EndpointBehaviors.Clear();
		imaging.ChannelFactory.Endpoint.EndpointBehaviors.Add(new SoapSecurityHeaderBehavior(username, password, time_shift));

		// Connectivity Test
		await imaging.OpenAsync().ConfigureAwait(false);

		return imaging;
	}

    public static async Task<EventClient> CreateEventClientAsync(string xAddress, string username, string password)
    {
        var binding = CreateBinding();
        var device = await CreateDeviceClientAsync(new Uri(xAddress), username, password).ConfigureAwait(false);
        var caps = await device.GetCapabilitiesAsync([CapabilityCategory.Events]).ConfigureAwait(false);
        var eventClient = new EventClient(binding, new EndpointAddress(new Uri(caps.Capabilities.Events.XAddr)));

        var time_shift = await GetDeviceTimeShift(device).ConfigureAwait(false);
        eventClient.ChannelFactory.Endpoint.EndpointBehaviors.Clear();
        eventClient.ChannelFactory.Endpoint.EndpointBehaviors.Add(new SoapSecurityHeaderBehavior(username, password, time_shift));

        // Connectivity Test
        await eventClient.OpenAsync().ConfigureAwait(false);

        return eventClient;
    }

    public static async Task<TimeSpan> GetDeviceTimeShift(this DeviceClient device)
	{
		var utc = (await device.GetSystemDateAndTimeAsync().ConfigureAwait(false)).UTCDateTime;
		var dt = new System.DateTime(utc.Date.Year, utc.Date.Month, utc.Date.Day,
						  utc.Time.Hour, utc.Time.Minute, utc.Time.Second);
		return dt - System.DateTime.UtcNow;
	}
}
