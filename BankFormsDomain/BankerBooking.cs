using BankFormsDal.dto;
using BankFormsDal.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BankFormsDomain
{
    public class BankerBooking : IBankerBooking, ILeadComsMethods
    {
        private BankerBookingDto _bankerBooking;
        public object setContatNoInput;

        private IBankerBookingDal _bankerBookingDal { get;  set; }

        public BankerBooking(IBankerBookingDal bankerBookingDal)
        {
            _bankerBookingDal = bankerBookingDal;
            _bankerBooking = new BankerBookingDto();
            _bankerBooking.lead = new LeadDto();
           

        }

    

        public BankerBooking(IBankerBookingDal bankerBookingDal, BankerBookingDto bankerBooking)
        {
            _bankerBookingDal = bankerBookingDal;
            _bankerBooking = bankerBooking;
        }

        public long getId() { return _bankerBooking.id; }
        public int getTitle() { return _bankerBooking.lead.title; }
        public string getFirstName() { return _bankerBooking.lead.firstName; }
        public bool getExistingClient() { return _bankerBooking.existingClient; }
        public string getQuery() { return _bankerBooking.query; }
        public int getBankingRegion() { return _bankerBooking.bankingRegion; }
        public int getProvisionalTime() { return _bankerBooking.provisionalTimeSlot; }
        public DateTime getProvisionalDate() { return _bankerBooking.provisionalDate; }

        public void setTitle(int value) { _bankerBooking.lead.title = value; }
        public string getContactNo(string value) { return _bankerBooking.lead.contactNo = value; }
        public void setContactNo(string value) { _bankerBooking.lead.contactNo = value; }
        public string getSurname(string value) { return _bankerBooking.lead.surname = value; }
        public void setSurname(string value) { _bankerBooking.lead.surname = value;}
        public string getCompany(string value) { return _bankerBooking.company = value; }
        public void setCompany(string value) { _bankerBooking.company = value;}
        public string getEmailAddress(string value) { return _bankerBooking.lead.emailAddress = value; }
        public void setEmailAddress(string value) { _bankerBooking.lead.emailAddress = value;}
        public void setFirstName(string value) { _bankerBooking.lead.firstName = value; }
        public void setExistingClient(bool value) { _bankerBooking.existingClient = value; }
        public void setQuery(string value) { _bankerBooking.query = value; }
        public void add(List<LeadComsMethodDto> value) { _bankerBooking.add(value); }
        public void setBankingRegion(int value) { _bankerBooking.bankingRegion = value; }
        public void setProvisionalTime(int value) { _bankerBooking.provisionalTimeSlot = value; }
        public void setProvisionalDate(DateTime value) { _bankerBooking.provisionalDate = value; }
        


        public BankerBookingDto getBankerBookingDto()
        {
            return _bankerBooking;
        }
        public List<LeadComsMethodDto> getLeadComsMethodsDto()
        {
            return _bankerBooking.getLeadComsMethodsDto();
        }


        /// <summary>
        /// Gets validation violations object data
        /// </summary>
        /// <returns></returns>
        public List<string> getValidationErrors()
        {
            return new List<string>() ;
        }

        public bool isValid()
        {
            return getValidationErrors().Count() == 0;
        }
        public void save()
        {
            if (isValid())
            {
                if(_bankerBooking.id == 0)
                {
                  _bankerBookingDal.insert(_bankerBooking);
                }
                else
                {
                    _bankerBookingDal.update(_bankerBooking);
                }
            }
            else
            {
                throw new Exception("Invalid banker booking");
            }
            
        }

     
    }
}
