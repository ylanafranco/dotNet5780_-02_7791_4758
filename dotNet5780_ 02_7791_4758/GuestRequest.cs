using System;

namespace dotNet5780__02_7791_4758
{
    public class GuestRequest
    {
        public bool IsApproved;
        //{ get; private set; }
        public DateTime EntryDate;
        //{ get; set; }
        public DateTime ReleaseDate; 
        //{ get; set; }

        public override string ToString()
        {
            String result = " ";
            result += String.Format("Entry Date is : {0}, Release Date is {1}", EntryDate.ToShortDateString(), ReleaseDate.ToShortDateString());
            if (IsApproved ==  true )
            {
                result += " the request is approved";
            }
            else
            {
                result += " the request is not approved";
            }
            return result;
        }
    }
}