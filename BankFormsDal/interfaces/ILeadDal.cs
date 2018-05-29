using BankFormsDal.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankFormsDal.interfaces
{
    public interface ILeadDal
    {
        List<TitleDto> getTitles();
        void insert(ILead lead);
        void  update(ILead lead);

        List<ComsMethodDto> getComsMethods();

        long insertLeadComs(long leadId, ILeadComsMethods leadComsMethods);
    }
}
