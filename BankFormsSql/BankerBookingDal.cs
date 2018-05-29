using BankFormsDal.interfaces;
using System;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using BankFormsDal.dto;
using System.Collections.Generic;
using System.Linq;

namespace BankFormsSql
{
    public class BankerBookingDal : IBankerBookingDal
    {
        public List<BankerTimeSlotDto> getBankerTimeSlots()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                string sql = @"SELECT Id, Caption FROM BankerMeetingSlot;";

                db.Open();

                var timeSlots= db.Query<BankerTimeSlotDto>(sql).ToList();
                return timeSlots;
            }
        }

        public List<BankingRegionDto> getBankingRegions()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                string sql = @"SELECT Id, Caption FROM BankingRegion;";

                db.Open();

                var bankingRegions = db.Query<BankingRegionDto>(sql).ToList();
                return bankingRegions;
            }
        }

        public void insert(IBankerBooking newBankerBooking)
        {
            var bankerBooking = newBankerBooking.getBankerBookingDto();

            using (var transactionScope = new TransactionScope())
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
                {
                    LeadDal leadDal = new LeadDal();
                    leadDal.insert(bankerBooking);

                    string sqlQuery = @"Insert INTO BankerBooking 
                                        (LeadId, Company, ExistingClient, Query, BankingRegionID, 
                                         PreferredDate, PreferredTimeSlotId) 
                                        Values
                                        (@LeadId, @Company, @ExistingClient, @Query, @BankingRegionID, 
                                         @PreferredDate, @PreferredTimeSlotId);
                        SELECT CAST(SCOPE_IDENTITY() as bigint)";

                    var idobj  = db.ExecuteScalar(sqlQuery,
                       new {

                           LeadId = bankerBooking.lead.id,
                           Company = bankerBooking.company,
                           existingClient = bankerBooking.existingClient,
                           query = bankerBooking.query,
                           bankingRegionId = bankerBooking.bankingRegion,
                           preferredDate = bankerBooking.provisionalDate,
                           preferredTimeSlotId = bankerBooking.provisionalTimeSlot
                        });

                    bankerBooking.id =  long.Parse(idobj.ToString());

                }

                
                transactionScope.Complete();
            }
        }

        public void update(IBankerBooking bankerBooking)
        {
            throw new NotImplementedException();
        }
    }
}
