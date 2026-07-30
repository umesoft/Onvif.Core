using Onvif.Core.Discovery.Common;
using Onvif.Core.Discovery.Interfaces;
using Onvif.Core.Discovery.Models;
using Onvif.Core.Internals;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Onvif.Core.Discovery;

public class WSDiscovery : IWSDiscovery
{
    public IAsyncEnumerable<DiscoveryDevice> Discover(IPAddress ipAddress, int port,
	    TimeSpan timeout,
        CancellationToken cancellationToken = default)
    {
        return DiscoverProc(ipAddress, port, timeout, cancellationToken);
    }

    private async IAsyncEnumerable<DiscoveryDevice> DiscoverProc(IPAddress ipAddress, int port,
    	TimeSpan timeout,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
    {
        using var client = new UdpClientWrapper(ipAddress, port);

        await SendProbe(client).ConfigureAwait(false);

        while (true)
        {
            var response = await client.ReceiveAsync(
                timeout,
                cancellationToken);
            if (response == null)
            {
                yield break;
            }

            foreach (var device in ProcessResponse(response.Value))
            {
                if (device != null)
                {
                    yield return device;
                }
            }
        }
    }

    async Task SendProbe(IUdpClient client)
    {
        var message = WSProbeMessageBuilder.NewProbeMessage();
        var multicastEndpoint = new IPEndPoint(IPAddress.Parse(Constants.WS_MULTICAST_ADDRESS), Constants.WS_MULTICAST_PORT);
        await client.SendAsync(message, message.Length, multicastEndpoint).ConfigureAwait(false);
    }

    IEnumerable<DiscoveryDevice> ProcessResponse(UdpReceiveResult response)
    {
        var devices = new List<DiscoveryDevice>();
        string strResponse = Encoding.UTF8.GetString(response.Buffer);
        if (string.IsNullOrEmpty(strResponse))
        {
            return devices;
        }

        try
        {
            XmlSerializer serializer = new(typeof(XmlProbeReponse));
            XmlReaderSettings settings = new();
            using StringReader textReader = new(strResponse);
            using XmlReader xmlReader = XmlReader.Create(textReader, settings);
            XmlProbeReponse xmlResponse = (XmlProbeReponse)serializer.Deserialize(xmlReader);

            foreach (var probeMatch in xmlResponse.Body.ProbeMatches)
            {
                try
                {
                    ScopesParser.Parse(probeMatch.Scopes, out var name, out var model);

                    var discoveryDevice = new DiscoveryDevice
                    {
                        EndpointReferenceAddress = probeMatch.EndpointReference?.Address,
                        Address = response.RemoteEndPoint.Address,
                        XAdresses = ConvertToList(probeMatch.XAddrs),
                        Types = ConvertToList(probeMatch.Types),
                        Model = model,
                        Name = name
                    };

                    devices.Add(discoveryDevice);
                }
                catch (Exception ex)
                {
                    Debug.Fail(ex.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Fail(ex.ToString());
        }

        return devices;
    }

    private static IReadOnlyList<string> ConvertToList(string spacedListString)
    {
        if (string.IsNullOrWhiteSpace(spacedListString))
        {
            return Array.Empty<string>();
        }

        return spacedListString
            .Split((char[])null, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
}
