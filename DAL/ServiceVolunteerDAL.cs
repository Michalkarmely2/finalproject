﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceVolunteerDAL
    {
        HelpForElderlyEntities db = new HelpForElderlyEntities();

        public List<ArrangedRequests> GetAllArrangedRequestsWithRelations()
        {
            return db.ArrangedRequests.ToList();
        }
            //2
            public  List<Volunteer> VolunteersHaveMostHoursToDonateLeft(int idS)
            {

                var id = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Size = 9,
                    Value = idS
                };
               return db.Database.SqlQuery<Volunteer>("EXEC VolunteersHaveMostHoursToDonateLeft(@id)", id).ToList();

            }


    }
}
