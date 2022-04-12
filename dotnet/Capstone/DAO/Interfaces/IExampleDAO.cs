using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IExampleDAO
    {
        CodeExample GetExample(int codeId);
        List<CodeExample> GetExamples();
        NewExample AddExample(NewExample newExample);
       
    }
}