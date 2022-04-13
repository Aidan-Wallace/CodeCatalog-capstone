using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface ISearchQueryDAO
    {
        List<CodeExample> SearchByKeyword(string keyword);

        // List<CodeExample> SearchByTitle(string title);
        // List<CodeExample> SearchByDescription(string codeDescription);
        // List<CodeExample> SearchByCategory(string category);
        // List<CodeExample> SearchByProgrammingLanguage(string programmingLanguage);
         
        // SearchQuery AddSearchKeyword(string keyWord, int userId);
        // SearchQuery GetExampleWithSearchKeyword(string keyword);
    }
}
