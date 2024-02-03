using AdventureWorks.BusinessManager.Interface;
using AdventureWorks.DataAccessLayer;
using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdventureWorks.BusinessManager
{
    public class GetAllPersons : IGetPerson
    {
        private readonly GetAllPersonDetails _getPersons;

        public GetAllPersons()
        {
            _getPersons = new GetAllPersonDetails();
        }

        public List<Person> GetDetails(int currentPage, int recordsPerPage)
        {
            DataTable dt = _getPersons.GetPersons();

            List<Person> output = TransformDetails(dt.AsEnumerable(),currentPage,recordsPerPage);
            if (output.Count > 0)
            {
                output[0].totalRecords = dt.Rows.Count;
            }
            return output;
        }

        private List<Person> TransformDetails(EnumerableRowCollection<DataRow> rows,int currentPage,int recordsPerPage)
        {
            List<Person> person = rows.Skip((currentPage-1)* recordsPerPage).Take(recordsPerPage).Select(x=> new Person
            {
                FirstName = x["FirstName"].ToString(),
                LastName = x["LastName"].ToString(),
                EmailAddress = x["EmailAddress"].ToString(),
                PhoneNumber = x["PhoneNumber"].ToString(),
                Address = x["Address"].ToString(),
                Demographics = new List<Demographics>()
                {
                    new Demographics()
                    {
                        Age = Convert.ToInt32(x["Age"]),
                        Gender = x["Gender"].ToString(),
                        MaritalStatus = x["MaritalStatus"].ToString(),
                        Education = x["Education"].ToString()
                    }
                }.ToList(),
            }).ToList();
            return person;
        }
    }
}