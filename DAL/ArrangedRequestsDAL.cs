using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ArrangedRequestsDAL
    {
        HelpForElderlyEntities db=new HelpForElderlyEntities();
        public List<ArrangedRequests> GetArrangedRequests()
        {
            return db.ArrangedRequests.ToList();
        }
        //6
        public List<getNextVolunteeringDetails_Result> getNextVolunteeringDetails(string id)
        {
            var idV = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = System.Data.SqlDbType.NChar,
                Size = 9,
                Value = id
            };
           return db.Database.SqlQuery<List<getNextVolunteeringDetails_Result>>("EXEC getNextVolunteeringDetails(@idVolunteer)", idV).FirstOrDefault();

        }


    }
}
