using BankFormsDal.interfaces;
using BankFormsDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankForms.Tests
{
    [TestClass]
    public class BankerBookingTest : IoCSupportedTest<BankFormsModule>
    {

        private IBankerBookingDal bankerBookingDal;

        [TestInitialize]
        public void Setup()
        {
            this.bankerBookingDal = Resolve<IBankerBookingDal>();
        }

        [TestCleanup]
        public void TearDown()
        {
            bankerBookingDal = null;
            ShutdownIoC();
        }

        [TestMethod]
        public void NewBankerBooking()
        {
            BankerBooking booking = new BankerBooking(bankerBookingDal);
            booking.setTitle(1);
            booking.setFirstName("John");
            booking.setSurname("Due");
            booking.setContactNo("0700000000");
            booking.setEmailAddress("john@email.com");
            booking.setCompany("Store");
            booking.setExistingClient(true);
            booking.setQuery("Banking");
            booking.add(new List<BankFormsDal.dto.LeadComsMethodDto>() { new BankFormsDal.dto.LeadComsMethodDto() { comsMethodId = 1 } });
            booking.setProvisionalTime(1);
            booking.setProvisionalDate(DateTime.Now.AddDays(2));

            booking.save();

            Assert.AreNotEqual(0, booking.getId(), "Saved booking id cannot be zero");

        }



    }
}
