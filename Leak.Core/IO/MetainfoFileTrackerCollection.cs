﻿using Leak.Core.Encoding;
using System.Collections;
using System.Collections.Generic;

namespace Leak.Core.IO
{
    public class MetainfoFileTrackerCollection : IEnumerable<MetainfoFileTracker>
    {
        private readonly BencodedValue data;

        public MetainfoFileTrackerCollection(BencodedValue data)
        {
            this.data = data;
        }

        public IEnumerator<MetainfoFileTracker> GetEnumerator()
        {
            ICollection<string> result = new HashSet<string>();

            data.Find("announce", node =>
            {
                if (node != null)
                {
                    result.Add(node.ToText());
                }

                return node;
            });

            data.Find("announce-list", node =>
            {
                if (node != null)
                {
                    foreach (string text in node.AllTexts())
                    {
                        result.Add(text);
                    }
                }

                return node;
            });

            foreach (string uri in result)
            {
                yield return new MetainfoFileTracker(uri);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}