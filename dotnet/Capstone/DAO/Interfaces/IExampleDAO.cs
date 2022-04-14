using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
    public interface IExampleDAO
    {
        CodeExample GetExample(int codeId);
        List<CodeExample> GetExamples();
        PendingExample AddExample(PendingExample newExample);
        

    }
}
