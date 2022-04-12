using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Capstone.DAO.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers 
{
    [Route("examples")]
    [ApiController]
    public class ExampleController:ControllerBase 
    {
        private readonly IExampleDAO exampleDAO;
        public ExampleController(IExampleDAO exampleDAO)
        {
            this.exampleDAO=exampleDAO;
        }

        //GetExample Method
        [HttpGet("{codeId}")]
        public ActionResult<CodeExample> GetExample(int codeId)
        {
            CodeExample example = exampleDAO.GetExample(codeId);
            return Ok(example);
        }

        //GetExample List Method
        [HttpGet("{codeId}")]
        public ActionResult<List<CodeExample>> GetExamples()
        {
            List<CodeExample> exampleList = exampleDAO.GetExamples();
            return Ok(exampleList);
        }

        //AddExample Method
        [HttpPost()] //we'll probably have to add a user id here but we can figure it out later, will also have to add a join to our sql script to account for userid in the model
        public ActionResult<NewExample> AddExample(NewExample newExample)
        {
            NewExample newExampleCode =exampleDAO.AddExample(newExample);
            return Ok(newExampleCode);
        }
    }
}