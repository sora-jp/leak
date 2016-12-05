﻿using FluentAssertions;
using Leak.Common;
using Leak.Core.Leakage;
using Leak.Core.Tests.Core;
using NUnit.Framework;

namespace Leak.Core.Tests.Components
{
    public class LeakageTests
    {
        private LeakHooks hooks;

        [SetUp]
        public void SetUp()
        {
            hooks = new LeakHooks();
        }

        [Test]
        public void ShouldStartListener()
        {
            LeakConfiguration configuration = new LeakConfiguration
            {
                Port = 8099,
                Peer = PeerHash.Random()
            };

            Trigger trigger = Trigger.Bind(ref hooks.OnListenerStarted, data =>
             {
                 data.Port.Should().Be(configuration.Port);
                 data.Peer.Should().Be(configuration.Peer);
             });

            using (LeakClient client = new LeakClient(hooks, configuration))
            {
                trigger.Wait().Should().BeTrue();
            }
        }

        [Test]
        public void ShouldDealWithoutListener()
        {
            LeakConfiguration configuration = new LeakConfiguration
            {
                Peer = PeerHash.Random()
            };

            using (LeakClient client = new LeakClient(hooks, configuration))
            {
            }
        }
    }
}