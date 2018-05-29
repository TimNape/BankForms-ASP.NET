using BankFormsDal.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BankFormsDal.dto;

namespace BankFormsSql
{
    public class LeadDal : ILeadDal
    {
        public List<ComsMethodDto> getComsMethods()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                string sql = @"SELECT Id, Caption FROM ComsMethod;";

                db.Open();

                var comsMethods = db.Query<ComsMethodDto>(sql).ToList();
                return comsMethods;
            }
        }

        public List<TitleDto> getTitles()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                string sql = @"SELECT Id, Caption FROM Title;";

                db.Open();

                var titles = db.Query<TitleDto>(sql).ToList();
                return titles;
            }
        }

        public void insert(ILead newLead)
        {
            var lead = newLead.getLeadDto();

            

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                string sqlQuery = @"Insert INTO Lead 
                                    (Firstname, Surname, TitleId, IdentityNo , ContactNo, EmailAddress) 
                              Values(@FirstName, @Surname, @TitleId, @IdentityNo, @ContactNo, @EmailAddress);
                    SELECT CAST(SCOPE_IDENTITY() as bigint)";

                var id = db.ExecuteScalar(sqlQuery,
                   new
                   {

                       FirstName = lead.firstName,
                       Surname = lead.surname,
                       TitleId = lead.title, 
                       IdentityNo = lead.identityNo,
                       EmailAddress = lead.emailAddress,
                       ContactNo = lead.contactNo

                   });
                lead.id = long.Parse(id.ToString());

                //save lead comsmethod opt-ins
                insertLeadComs(lead.id, lead);
            }
        }

        public long insertLeadComs(long leadId, ILeadComsMethods newleadComsMethods)
        {

            var leadComsMethods = newleadComsMethods.getLeadComsMethodsDto();

            int count = 0;

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                string sql = @"INSERT INTO LeadComsMethod (LeadID, ComsMethodID) 
                          VALUES (@LeadID, @ComsMethodID)";

                db.Open();
                foreach (var leadComsMethod in leadComsMethods)
                {
                    count += db.Execute(sql, new { LeadID = leadId, ComsMethodID = leadComsMethod.comsMethodId });

                }
            }

            return count;

        }

        public void update(ILead lead)
        {
            throw new NotImplementedException();
        }
    }
}
