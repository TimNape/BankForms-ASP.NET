using Autofac;
using BankFormsDal.interfaces;
using BankForms.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankForms.Tests
{
    public class BankFormsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
         
            builder.RegisterType<BankerBookingDal>().As<IBankerBookingDal>();
            builder.RegisterType<LeadDal>().As<ILeadDal>();
            //register other modules/dependencies here

        }
    }
}
