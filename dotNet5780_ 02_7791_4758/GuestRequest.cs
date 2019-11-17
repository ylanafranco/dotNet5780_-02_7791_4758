using System;

namespace dotNet5780__02_7791_4758
{
    public class GuestRequest
    {
        public bool IsApproved { get; internal set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            String result = " ";
            // TO DO 
            result += String.Format("Entry Date is : {0}, Release Date is {1}", EntryDate.ToShortDateString(), ReleaseDate.ToShortDateString());
            result += ("is " + ((IsApproved) ? "" : "not ") + "approved");
            return result;
        }
    }
}