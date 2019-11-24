using System;
using System.Collections;
using System.Collections.Generic;


namespace dotNet5780__02_7791_4758
{
    public class Host : IEnumerable<HostingUnit>
    {
        public int HostKey; // id du mec
        // list d'hebergement qui appartiennent a une personne
        public List<HostingUnit> HostingUnitCollection { get; private set; }

        public Host(int id, int hostUnitCollec)
        {
            this.HostKey = id;
            HostingUnitCollection = new List<HostingUnit>();

            for (int i = 0; i < hostUnitCollec; i++)
            {
                this.HostingUnitCollection.Add(new HostingUnit());

            }
           
        }

        public override string ToString()
        {
            string result = " ";
            result += ("the host id is " + this.HostKey + ", and has this Hosting Unit Collection:\n ");
            foreach (HostingUnit item in this.HostingUnitCollection)
            {
                result += item.ToString() + "\n";
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

        //IEnumerator<HostingUnit> GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}

        public IEnumerator<HostingUnit> GetEnumerator()
        {
            return this.HostingUnitCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public HostingUnit this[int HostNumber]
        {

            get 
            {

                //for (int i = 0; i < this.HostingUnitCollection.Count; i++)
                //{
                    //if (this.HostingUnitCollection[i].HostingUnitKey == HostNumber)
                        return HostingUnitCollection[HostNumber];
                //}
                //return null; 
            }
        }
        
    }
}