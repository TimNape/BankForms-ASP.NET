using BankFormsDal.dto;
using BankFormsDal.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankForms.Mock
{
    public class BankerBookingDal : IBankerBookingDal
    {
        private List<BankerBookingDto> bankerBookings = new List<BankerBookingDto>();

        public List<BankerTimeSlotDto> getBankerTimeSlots()
        {
            return new List<BankerTimeSlotDto>
            {
             new BankerTimeSlotDto() { id=1, caption = "08:00 - 11:00" },
             new BankerTimeSlotDto() { id=2, caption = "11:00 - 14:00"},
             new BankerTimeSlotDto() { id=3, caption = "14:00 - 17:00"}
            };
        }

        public List<BankingRegionDto> getBankingRegions()
        {
            return new List<BankingRegionDto>
            {

                new BankingRegionDto () { id = 1,   caption="Eastern Cape"},
                new BankingRegionDto () { id = 2,   caption="Freestate and Northern Cape"},
                new BankingRegionDto () { id = 3,   caption="Gauteng Central"},
                new BankingRegionDto () { id = 4,   caption="Gauteng East"},
                new BankingRegionDto () { id = 5,   caption="Gauteng North"},
                new BankingRegionDto () { id = 6,   caption="KwaZulu Natal"},
                new BankingRegionDto () { id = 7,   caption="Limpopo and Mpumalanga"},
                new BankingRegionDto () { id = 8,   caption="Tswane"},
                new BankingRegionDto () { id = 9,   caption="Western Cape"},
            };
        }

        public void insert(IBankerBooking newBankerBooking)
        {
            var bankerBooking = newBankerBooking.getBankerBookingDto();
            bankerBookings.Add(bankerBooking);
            bankerBooking.id =  bankerBookings.Count();
        }

        public void update(IBankerBooking bankerBooking)
        {
            var data = bankerBooking.getBankerBookingDto();
            bankerBookings[Convert.ToInt32(data.id)] = data;
        }
    }
}
