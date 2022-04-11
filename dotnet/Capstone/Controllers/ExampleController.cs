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

        
        // route
        //public 
        // constructor
        // http requests/responses
    }
}