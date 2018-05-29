using BankFormsDal.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankFormsDal.dto;

namespace BankForms.Mock
{
    public class LeadDal : ILeadDal
    {
        public List<ComsMethodDto> getComsMethods()
        {
            return new List<ComsMethodDto>
            {
             new ComsMethodDto() { id=1, caption = "Phone" },
             new ComsMethodDto() { id=2, caption = "Email"}
            };
        }

        public List<TitleDto> getTitles()
        {
            return new List<TitleDto>
            {


                new TitleDto() {id = 1   , caption = "Mr" },
                new TitleDto() {id = 2   , caption = "Ms" },
                new TitleDto() {id = 3   , caption = "Mrs" },
                new TitleDto() {id = 4   , caption = "Miss" }
            };
        }

        public void insert(ILead lead)
        {
          
        }

        public long insertLeadComs(long leadId, ILeadComsMethods leadComsMethods)
        {
            return 1;
        }

        public void update(ILead lead)
        {
           
        }
    }
}
