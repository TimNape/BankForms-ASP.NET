using BankFormsDal.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankFormsDal.dto
{
    public class LeadDto : ILead, ILeadComsMethods
    {
      

        public LeadDto()
        {
            leadComs = new List<LeadComsMethodDto>();
        }
        public long id { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string emailAddress { get; set; }
        public string contactNo { get; set; }
        public int title { get; set; }
        public string identityNo { get; set; }
        public DateTime DateCreated { get; set; }
        public List<LeadComsMethodDto> leadComs { get; private set; }


        public LeadDto getLeadDto()
        {
            return this;
        }

        public List<LeadComsMethodDto> getLeadComsMethodsDto()
        {
            return leadComs;
        }

        public void add(List<LeadComsMethodDto> leadComsMethods)
        {
            leadComs.AddRange(leadComsMethods);
        }

       
    }
}
