
using System.Collections.Generic;
using BankFormsDal.dto;

namespace BankFormsDal.interfaces
{
    public interface IBankerBookingDal
    {
        void insert(IBankerBooking _bankerBooking);
        void update(IBankerBooking bankerBooking);

        List<BankingRegionDto> getBankingRegions();
        List<BankerTimeSlotDto> getBankerTimeSlots();
    }
}
