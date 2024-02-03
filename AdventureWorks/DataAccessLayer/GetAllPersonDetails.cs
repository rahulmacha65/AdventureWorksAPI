using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using AdventureWorks.Models;

namespace AdventureWorks.DataAccessLayer
{
    public class GetAllPersonDetails
    {
        private readonly string _connectionString;
        public GetAllPersonDetails()
        {
            this._connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
        }

        public DataTable GetPersons()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(this._connectionString))
            {
                SqlDataAdapter ad = new SqlDataAdapter("spGetPersonDetails", con);
                ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                
                ad.Fill(dt);
            }
            return dt;
        }

    }
}