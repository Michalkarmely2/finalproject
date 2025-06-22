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
            return db.getNextVolunteeringDetails(id).ToList();

        }


    }
}
