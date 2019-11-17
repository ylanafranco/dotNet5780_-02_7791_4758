using System;
using System.Collections;
using System.Collections.Generic;

namespace dotNet5780__02_7791_4758
{
    public class Host : IEnumerable<HostingUnit>
    {
        public int HostKey;
        public int[] HostingUnitCollection;

        public Host(int v1, int v2)
        {
            this.HostKey = v1;
            this.v2 = v2;
        }

        public List<HostingUnit> HostingUnitCollection { get; internal set; }

        public void AssignRequests(params GuestRequest[] gs1)
        {
            throw new NotImplementedException();
        }

        IEnumerator<HostingUnit> IEnumerable<HostingUnit>.GetEnumerator()
        {
            return hostingUnits.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public HostingUnit this[int index]
        {
            get { return HostingUnits[index]; }
            set { /* set the specified index to value here */ }
        }
        public void SortUnits()
        {
            HostingUnitCollection.sort();
        }
    }
}