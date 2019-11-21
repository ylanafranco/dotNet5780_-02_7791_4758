using System;
using System.Collections;
using System.Collections.Generic;


namespace dotNet5780__02_7791_4758
{
    public class Host : IEnumerable<HostingUnit>
    {
        public int HostKey; // id du mec
        // list d'hebergement qui appartiennent a une personne
        public List<HostingUnit> HostingUnitCollection { get; internal set; }

        public Host(int id, int hostUnitCollec)
        {
            this.HostKey = id;
            for (int i = 1; i <= hostUnitCollec; i++)
            {
                this.HostingUnitCollection.Add(new HostingUnit());

            }
           
            foreach (HostingUnit item in this.HostingUnitCollection)
            {
                item.init();
            }
        }

        public override string ToString()
        {
            string result = " ";
            result += ("the host id is {0}, and has this Hosting Unit Collection:\n ", HostKey);
            foreach (HostingUnit item in this.HostingUnitCollection)
            {
                result += item.ToString();
            }
            return result;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (HostingUnit item in this.HostingUnitCollection)
            {
                bool flag = item.ApproveRequest(guestReq);
                if (flag == true)
                {
                    return item.HostingUnitKey;
                }
            }
            return -1;
        }

        public int GetHostAnnualBusyDays()
        {
            int count = 0;
            foreach (HostingUnit item in this.HostingUnitCollection)
            {
                count += item.GetAnnualBusyDays();
            }
            return count;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }
        public bool AssignRequests(params GuestRequest[] gs)
        {
            long num;
            foreach (GuestRequest item in gs)
            {
                num = SubmitRequest(item);
                if (num == -1)
                {
                    return false;
                }
            }
            return true;
        }

        IEnumerator<HostingUnit> GetEnumerator()
        {
            return HostingUnit.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }


        public HostingUnit this[int HostNumber]
        {

            get 
            {
                //foreach (HostingUnit item in this.HostingUnitCollection)
                //{
                //    if (item.HostingUnitKey == HostNumber)
                //    {
                //        return item;
                //    }
                //}

                for (int i = 0; i < HostingUnitCollection.Count; i++)
                {
                    if (HostingUnitCollection[i].HostingUnitKey == HostNumber)
                        return HostingUnitCollection[i];
                }
                return null; 
            }
        }
        
    }
}