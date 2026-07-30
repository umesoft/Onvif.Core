using Onvif.Core.Discovery.Models;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace Onvif.Core.Discovery.Interfaces;

public interface IWSDiscovery
{
    IAsyncEnumerable<DiscoveryDevice> Discover(IPAddress ipAddress, int port,
        TimeSpan timeout,
        CancellationToken cancellationToken = default);
}
