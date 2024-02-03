using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BusinessManager.Interface
{
    public interface IGetPerson
    {
        List<Person> GetDetails(int currentPage, int recordsPerPage);
    }
}
