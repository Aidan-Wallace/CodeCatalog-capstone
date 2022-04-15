using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
    public interface IExampleDAO
    {

//users can get example(s)
        CodeExample GetExample(int codeId);
        List<CodeExample> GetExamples();

//download examples
        CodeExample FetchScript(int codeId);
        List<CodeExample> FetchAllScripts();

//users can add examples
        PendingExample AddExample(PendingExample newExample);

//Admin can edit submission status
        List<PendingExample> GetExamplesByStatus(int submissionStatus);
        PendingExample ApproveStatus(int codeId);
        PendingExample RejectStatus(int codeId);

    }
}
