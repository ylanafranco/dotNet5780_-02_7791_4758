using Microsoft.VisualStudio.TestTools.UnitTesting;
using dotNet5780__02_7791_4758;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780__02_7791_4758.Tests
{
    [TestClass()]
    public class GuestRequestTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            GuestRequest gs = new GuestRequest 
            { 
                EntryDate = DateTime.Today, 
                ReleaseDate = DateTime.Today.AddDays(5) 
            };
            Console.WriteLine(gs);
        }
    }
}