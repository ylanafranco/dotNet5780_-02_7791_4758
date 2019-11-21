using System;
using System.Collections.Generic;

namespace dotNet5780__02_7791_4758
{
    public class HostingUnit : IComparable<HostingUnit>
    {
        // numero d'hebergement 
        private static int stSerialKey = 10000000;
        // numero d'hebergement hanohari
        public int HostingUnitKey 
        { 
            get => stSerialKey; 
            private set => stSerialKey++;
        }
        // matrix about the month and the date 
        // peut etre changer a 13 et 32
        private bool[,] diary = new bool[13, 32];

        public bool[,] Diary 
        {
            get { return diary; }
        }


        public int GetAnnualBusyDays()
        {
            int BusyDay = 0;
            foreach (bool item in Diary)
            {
                BusyDay += (item) ? 1 : 0;

            }
            return BusyDay;
        }

        public void init()
        {
            for (int i = 0; i < diary.GetLength(0); i++)
            {
                for (int j = 0; j < diary.GetLength(1); j++)
                {
                    diary[i, j] = false;
                }
            };
        }

        public float GetAnnualBusyPercentage()
        {
            return GetAnnualBusyDays() / (12f * 31f);
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            DateTime i = guestReq.EntryDate;
            if (diary[guestReq.EntryDate.Month, guestReq.EntryDate.Day] == false)
            {
                while(i != guestReq.ReleaseDate)
                {

                    if (diary[i.Month, i.Day] == true)
                    {
                        guestReq.IsApproved = false;
                        return guestReq.IsApproved;
                    }
                    i = i.AddDays(1);

                }
                guestReq.IsApproved = true;
            }

            while (i != guestReq.ReleaseDate)
            {

                diary[i.Month, i.Day] = true;
                i = i.AddDays(1);

            }
            return guestReq.IsApproved;
        }

        public override string ToString()
        {
            String result = " ";
            int count = 0;
            result += ("The number of the hosting unit is {0}", HostingUnitKey);
            for (int i = 1; i < 13; i++)
            {

                int j = 1;
                while (j < 32)
                {
                    bool flag = false;
                    int tempj = j;
                    while (diary[i, j] == true && j < 32)
                    {
                        j = j + 1;
                        count++;
                        flag = true;
                    }


                    if (flag == true)
                    {
                        result += ("The host unit is busy since : {0}/{1}, to : {2}/{1}\n", tempj, i, tempj + count);

                    }
                    count = 0;
                    j++;

                }

                if (j == 31 && diary[i, j] == true)
                {
                    result += ("the host unit is occupied : {0}/{1}", j, i);
                }

            }
            return result;
        }

        //ca je suis pas sur
        internal static IEnumerator<HostingUnit> GetEnumerator()
        {
            yield return new HostingUnit();
        }

        int IComparable<HostingUnit>.CompareTo(HostingUnit other)
        {
            return GetAnnualBusyDays().CompareTo(other.GetAnnualBusyDays());
        }
    }
}