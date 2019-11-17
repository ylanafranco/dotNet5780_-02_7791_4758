using System;

namespace dotNet5780__02_7791_4758
{
    public class HostingUnit : IComparable<HostingUnit>
    {
        private static int stSerialKey = 10000000;
        public long HostingUnitKey { get => stSerialKey; }
        private bool[,] diary = new bool[12, 31];;

        public bool[,] Diary 
        {
            get { return diary = new bool[12, 31];; }
        }


        public int GetAnnualBusyDays()
        {
            int tfussim = 0;
            foreach (bool item in Diary)
            {
                tfussim += (item) ? 1 : 0;

            }
            return tfussim;
        }

        public float GetAnnualBusyPercentage()
        {
            return GetAnnualBusyDays() / (12f * 31f);
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            bool result = false;
            if (// A REMPLIR)
            {
                guestReq.IsApproved = true;
            }
            else
            {
                guestReq.IsApproved = false;
            }
            result = guestReq.IsApproved;
            return (result);
        }

        public override string ToString()
        {
            // A FAIRE
            return base.ToString();
        }

        int IComparable<HostingUnit>.CompareTo(HostingUnit other)
        {
            return GetAnnualBusyDays().CompareTo(other.GetAnnualBusyDays());
        }
    }
}