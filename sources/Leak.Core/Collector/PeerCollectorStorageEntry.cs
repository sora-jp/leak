﻿using Leak.Core.Common;
using Leak.Core.Network;

namespace Leak.Core.Collector
{
    public class PeerCollectorStorageEntry
    {
        public FileHash Hash { get; set; }

        public PeerHash Peer { get; set; }

        public NetworkConnection Connection { get; set; }

        public PeerCollectorChannel Channel { get; set; }

        public bool HasExtensions { get; set; }
    }
}