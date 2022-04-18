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
        CodeExample AddExample(CodeExample newExample);

//Admin can edit submission status
        List<CodeExample> GetExamplesByStatus(int submissionStatus);
        CodeExample UpdateStatus(int codeId, CodeExample codeExample);

        CodeExample UpdateVisibility(int codeId, CodeExample codeExample);
        CodeExample UpdateLanguage(int codeId, CodeExample codeExample);

        CodeExample UpdateGenericSet(int codeId, CodeExample codeExample);

        List<CodeExample> GetGenericExampleList(int genericExample);

    }
}
