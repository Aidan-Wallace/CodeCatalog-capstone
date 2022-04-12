using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public class ISearchQueryDAO
    {
        public SearchQuery SearchQuery(string keyword);
    }
}
