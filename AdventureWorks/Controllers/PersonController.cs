using AdventureWorks.BusinessManager;
using AdventureWorks.BusinessManager.Interface;
using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AdventureWorks.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Person")]
    public class PersonController : ApiController
    {
        private IGetPerson _getPerson;
        public PersonController()
        {
            _getPerson = new GetAllPersons();   
        }
        public List<Person> getDetails(int currentPage, int recordsPerPage)
        {
            List<Person>  output = _getPerson.GetDetails(currentPage, recordsPerPage);
            

            return output;
        }

    }
}
