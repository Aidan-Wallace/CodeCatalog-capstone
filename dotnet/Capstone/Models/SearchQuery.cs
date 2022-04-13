using System.Collections.Generic;
namespace Capstone.Models
{
    public class SearchQuery
    {
        public int userId {get; set;} //should not be nullable
        public string keyword {get;set;} //fed into db
        public string codeId {get; set;} //populated on way back
    }
}
