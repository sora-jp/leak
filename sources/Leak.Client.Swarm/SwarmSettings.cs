using Leak.Networking;

namespace Leak.Client.Swarm
{
    public class SwarmSettings
    {
        public SwarmSettings()
        {
            Listener = false;
            Connector = true;

            Strategy = "rarest-first";
            Metadata = true;
            Exchange = true;

            NetworkHooks = new NetworkPoolHooks();
        }

        public bool Listener { get; set; }
        public int? ListenerPort { get; set; }

        public bool Connector { get; set; }
        public SwarmFilter Filter { get; set; }

        public string Strategy { get; set; }
        public bool Metadata { get; set; }
        public bool Exchange { get; set; }

        public NetworkPoolHooks NetworkHooks { get; set; }
    }
}