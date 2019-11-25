using System;
using System.Collections.Generic;

namespace dotNet5780__02_7791_4758
{
    public class HostingUnit : IComparable<HostingUnit>
    {
        // numero d'hebergement 
        private static int stSerialKey = 10000000;

        // numero d'hebergement hanohari
        //public int HostingUnitKey
        //{
        //    get { return stSerialKey; }
        //    private set { this.HostingUnitKey = stSerialKey++; }
        //}

        public readonly long HostingUnitKey;

        // matrix about the month and the date 
        private bool[,] diary = new bool[13, 32];

        //public bool[,] Diary 
        //{
        //    get { return diary; }
        //}

        public HostingUnit()
        {
            HostingUnitKey = stSerialKey;
            stSerialKey++;
            init();
        }

        public int GetAnnualBusyDays()
        {
            int BusyDay = 0;
            foreach (bool item in diary)
            {
                //BusyDay += (item) ? 1 : 0;
                if (item == true)
                {
                    BusyDay++;
                }

            }
            return BusyDay;
        }

        private void init()
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
            return ((GetAnnualBusyDays()*100) /365);
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            DateTime i = guestReq.EntryDate;
            
            if (diary[guestReq.EntryDate.Month, guestReq.EntryDate.Day] == false)
            {
                while (i != guestReq.ReleaseDate)
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

            i = guestReq.EntryDate;
            while (i != guestReq.ReleaseDate)
            {

                diary[i.Month, i.Day] = true;
                i = i.AddDays(1);

            }
            return guestReq.IsApproved;
        }

        // en gros ici ca recoit une matrice toute false et pas nos matrices
        public override string ToString()
        {
            String result = " ";
            int count = 0;
            result += String.Format("The number of the hosting unit is {0} \n", HostingUnitKey);
            //printmat(diary);
            for (int i = 1; i < 13; i++)
            {
                int j = 1;
                while (j < 32)
                {
                    bool flag = false;
                    int tempj = j;

                    //Console.WriteLine("j =" + tempj );
                    while (((diary[i, j] == true) && (j < 31)))
                    {                       
                        j = j + 1;
                        count++;
                        flag = true;
                    }


                    if (flag == true)
                    {
                        
                        result += String.Format("The host unit is busy since : {0}/{1}, to : {2}/{1}\n", tempj, i, tempj + count);

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

        int IComparable<HostingUnit>.CompareTo(HostingUnit other)
        {
            return GetAnnualBusyDays().CompareTo(other.GetAnnualBusyDays());
        }

        //public void printmat(bool[,] d)
        //{
        //    Console.WriteLine("my diary is ");
        //    for (int i = 0; i < 13; i++) 
        //    { for (int j = 0; j < 32; j++)
        //            Console.Write("{0,-3}", d[i,j]);
        //        Console.WriteLine(); }
        //}
    }
}