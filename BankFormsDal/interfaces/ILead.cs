using BankFormsDal.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankFormsDal.interfaces
{
    public interface ILead
    {
        LeadDto getLeadDto();
    }
}
