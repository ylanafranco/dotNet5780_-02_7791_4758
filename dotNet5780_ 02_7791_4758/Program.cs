using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780__02_7791_4758
{
    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);

        private static GuestRequest CreateRandomRequest()
        {
            GuestRequest gs = new GuestRequest();
            int dayEntry = 0;
            int monthEntry = rand.Next(1, 12);
            if (monthEntry == 2)
            {
                dayEntry = rand.Next(1, 29);
            }
            else if (monthEntry == 4 || monthEntry==6 || monthEntry==9 || monthEntry==11)
            {
                dayEntry = rand.Next(1, 30);
            }
            else
            {
                dayEntry = rand.Next(1, 31);
            }
            gs.EntryDate = new DateTime(2020, monthEntry, dayEntry);
            int NumberOfDays = rand.Next(2, 10);
            gs.ReleaseDate = gs.EntryDate.AddDays(NumberOfDays);
            return gs;
        }

        static void Main(string[] args)
        {
            List<Host> lsHosts; lsHosts = new List<Host>();
            lsHosts.Add((new Host(1, rand.Next(1, 5))));
            lsHosts.Add((new Host(2, rand.Next(1, 5))));
            lsHosts.Add((new Host(3, rand.Next(1, 5))));
            lsHosts.Add((new Host(4, rand.Next(1, 5))));
            lsHosts.Add((new Host(5, rand.Next(1, 5))));

            foreach (var item in lsHosts)
            {
                Console.WriteLine(item.ToString());
            }

            for (int i = 0; i < 100; i++)
            {
                GuestRequest gs1 = new GuestRequest();
                GuestRequest gs2 = new GuestRequest();
                GuestRequest gs3 = new GuestRequest();


                foreach (var host in lsHosts)
                {
                    if (!gs1.IsApproved) gs1 = CreateRandomRequest();
                    if (!gs2.IsApproved) gs2 = CreateRandomRequest();
                    if (!gs3.IsApproved) gs3 = CreateRandomRequest();

                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            host.AssignRequests(gs1);
                            //Console.WriteLine(gs1.ToString());
                            break;
                        case 2:
                            host.AssignRequests(gs1, gs2);
                            //Console.WriteLine(gs1.ToString());
                            //Console.WriteLine(gs2.ToString());
                            break;
                        case 3:
                            host.AssignRequests(gs1, gs2, gs3);
                            //Console.WriteLine(gs1.ToString());
                            //Console.WriteLine(gs2.ToString());
                            //Console.WriteLine(gs3.ToString());
                            break;
                        default:
                            break;
                    }
                }
            }

            //Create dictionary for all units <unitkey, occupancy_percentage>             
            Dictionary<long, float> dict = new Dictionary<long, float>();
            foreach (var host in lsHosts)
            {                 //test Host IEnuramble is ok                 
                foreach (HostingUnit unit in host)
                {
                    dict[unit.HostingUnitKey] = unit.GetAnnualBusyPercentage();
                    Console.WriteLine(unit.GetAnnualBusyPercentage());
                    
                }
            }

            //get max value in dictionary             
            float maxVal = dict.Values.Max();

            //get max value key name in dictionary             
            long maxKey = dict.FirstOrDefault(x => x.Value == dict.Values.Max()).Key;
            Console.WriteLine(maxKey);

            //find the Host that its unit has the maximum occupancy percentage             
            foreach (var host in lsHosts)
            {
                //test indexer of Host                 
                for (int i = 0; i < host.HostingUnitCollection.Count; i++)
                {
                    if (host[i].HostingUnitKey == maxKey)
                    {
                        Console.WriteLine("coucou");
                        //sort this host by occupancy of its units                         
                        host.SortUnits();
                        //print this host detailes                         
                        Console.WriteLine("**** Details of the Host with the most occupied unit:\n"); 
                        Console.WriteLine(host); 
                        break;
                    }

                }

            }
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}


