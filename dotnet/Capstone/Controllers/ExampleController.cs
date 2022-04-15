using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Capstone.DAO.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleDAO exampleDAO;
        public ExampleController(IExampleDAO _exampleDAO)
        {
            exampleDAO = _exampleDAO;
        }

        //GetExample Method  -----WORKS-----
        [HttpGet("{codeId}")]
        public ActionResult<CodeExample> GetExample(int codeId)
        {
            CodeExample example = exampleDAO.GetExample(codeId);
            return Ok(example);
        }

        //GetExample List Method  -----WORKS-----
        [HttpGet()]
        public ActionResult<List<CodeExample>> GetExamples()
        {
            List<CodeExample> exampleList = exampleDAO.GetExamples();
            return Ok(exampleList);
        }

        //AddExample Method -----WORKS-----
        [HttpPost()] //we'll probably have to add a user id here but we can figure it out later, will also have to add a join to our sql script to account for userid in the model
        public ActionResult<PendingExample> AddExample(PendingExample newExample)
        {
            PendingExample newExampleCode = exampleDAO.AddExample(newExample);
            return Ok(newExampleCode);
        }

       

        // //SearchByKeyword Method
        // [HttpGet("{keyword}")]
        // public ActionResult<List<CodeExample>> SearchByKeyword(string keyword)
        // {
        //     List<CodeExample> exampleList = exampleDAO.SearchByKeyword(keyword);
        //     return Ok(exampleList);
        // }

        // //SearchByTitle Method
        // [HttpGet("{title}")]
        // public ActionResult<List<CodeExample>> SearchByTitle()
        // {
        //     List<CodeExample> exampleList = exampleDAO.SearchByTitle();
        //     return Ok(exampleList);
        // }

        // //SearchByCategory Method
        // [HttpGet("{category}")]
        // public ActionResult<List<CodeExample>> SearchByCategory()
        // {
        //     List<CodeExample> exampleList = exampleDAO.SearchByCategory();
        //     return Ok(exampleList);
        // }

        // //SearchByDescription Method
        // [HttpGet("{codeDescription}")]
        // public ActionResult<List<CodeExample>> SearchByDescription()
        // {
        //     List<CodeExample> exampleList = exampleDAO.SearchByDescription();
        //     return Ok(exampleList);
        // }

        // //SearchByProgrammingLanguage Method
        // [HttpGet("{programmingLanguage}")]
        // public ActionResult<List<CodeExample>> SearchByProgrammingLanguage()
        // {
        //     List<CodeExample> exampleList = exampleDAO.SearchByProgrammingLanguage();
        //     return Ok(exampleList);
        // }
    }
}
