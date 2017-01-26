﻿using Leak.Common;
using System;
using System.Collections.Generic;
using Leak.Dataget;
using Leak.Datamap;

namespace Leak.Leakage
{
    public static class LeakOmnibusExtensions
    {
        public static RetrieverOmnibus ToRetriver(this OmnibusService service)
        {
            return new OmnibusToRetriever(service);
        }

        private class OmnibusToRetriever : RetrieverOmnibus
        {
            private readonly OmnibusService service;

            public OmnibusToRetriever(OmnibusService service)
            {
                this.service = service;
            }

            public bool IsComplete(PieceInfo piece)
            {
                return service.IsComplete(piece.Index);
            }

            public void Complete(BlockIndex block)
            {
                service.Complete(block);
            }

            public void Complete(PieceInfo piece)
            {
                service.Complete(piece.Index);
            }

            public void Invalidate(PieceInfo piece)
            {
                service.Invalidate(piece.Index);
            }

            public void Schedule(string strategy, PeerHash peer, int count)
            {
                switch (strategy)
                {
                    case "rarest-first":
                        service.Schedule(OmnibusStrategy.RarestFirst, peer, count);
                        break;

                    case "sequential":
                        service.Schedule(OmnibusStrategy.Sequential, peer, count);
                        break;
                }
            }

            public void Query(Action<PeerHash, Bitfield, PeerState> callback)
            {
                service.Query(callback);
            }

            public IEnumerable<PeerHash> Find(int ranking, int count)
            {
                return service.Find(ranking, count);
            }
        }
    }
}