using BankFormsDal.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankFormsDal.dto
{
    public class BankerBookingDto : IBankerBooking, ILead, ILeadComsMethods
    {
      
        public long id { get; set; }
        public int bankingRegion { get; set; }
        
        public LeadDto lead { get; set; }
        public bool existingClient { get; set; }
        public string query { get; set; }
        public int provisionalTimeSlot { get; set; }
        public DateTime provisionalDate { get; set; }
        public string company { get; set; }

        public BankerBookingDto getBankerBookingDto()
        {
            return this;
        }

        public LeadDto getLeadDto()
        {
            return lead;
        }

        public List<LeadComsMethodDto> getLeadComsMethodsDto()
        {
            return lead.getLeadComsMethodsDto();
        }

        public void add(List<LeadComsMethodDto> leadComsMethod)
        {
            lead.add(leadComsMethod);
        }
    }
}
