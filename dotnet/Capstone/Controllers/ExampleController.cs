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
        public ActionResult<CodeExample> AddExample(CodeExample newExample)
        {
            CodeExample newExampleCode = exampleDAO.AddExample(newExample);
            return Ok(newExampleCode);
        }

        //AdminGetsListOfPending Method
        [HttpGet("status/{submissionStatus}")]
        public ActionResult<List<CodeExample>> GetExamplesByStatus(int submissionStatus)
        {
            List<CodeExample> pendingExamples = exampleDAO.GetExamplesByStatus(submissionStatus);
            return Ok(pendingExamples);
        }

        //AdminApprovesSubmissionStatus
        [HttpPut("update-status/{codeId}")]
        [Authorize(Roles = "admin")]
        public ActionResult<CodeExample> UpdateStatus(int codeId, CodeExample codeExample)
        {
            CodeExample existingExample = exampleDAO.GetExample(codeId);
            if(existingExample==null)
            {
                return NotFound();
            }
            CodeExample result = exampleDAO.UpdateStatus(codeId, codeExample);
            return Ok(result);
        }     

        //Make public after AddedCode has been approved by Admin
        [HttpPut("update-public/{codeId}")]
        public ActionResult<CodeExample> UpdateVisibility(int codeId, CodeExample codeExample)
        {
            CodeExample existingExample = exampleDAO.GetExample(codeId);
            if(existingExample == null)
            {
                return NotFound();
            }
            if (existingExample.submissionStatus != 1)
            {
                return Conflict(new { message = "Admin has not approved code. Cannot make public until approved." });
            }
            CodeExample result = exampleDAO.UpdateVisibility(codeId, codeExample);
            return Ok(result);
        }
        //Update the programming language of the code snippet
        [HttpPut("update-language/{codeId}")]
        [Authorize(Roles = "admin")]
        public ActionResult<CodeExample> UpdateLanguage(int codeId, CodeExample codeExample)
        {
            CodeExample existingExample = exampleDAO.GetExample(codeId);
            if (existingExample == null)
            {
                return NotFound();
            }
            CodeExample result = exampleDAO.UpdateLanguage(codeId, codeExample);
            return Ok(result);
        }

        //Updates the the initial list of generic code to be displayed to new users
        [HttpPut("update-initial/{codeId}")]
        [Authorize(Roles = "admin")]
        public ActionResult<CodeExample> UpdateInitialSet(int codeId, CodeExample codeExample)
        {
            CodeExample existingExample = exampleDAO.GetExample(codeId);
            if (existingExample == null)
            {
                return NotFound();
            }
            CodeExample result = exampleDAO.UpdateGenericSet(codeId, codeExample);
            return Ok(result);
        }
        //Gets the list of all code examples to be displayed to new users
        [HttpGet("initialset")]
        public ActionResult<List<CodeExample>> GetGenericExampleList(int genericExample)
        {
            List<CodeExample> currentExamples = exampleDAO.GetGenericExampleList(genericExample);
            return Ok(currentExamples);
        }
    }
}
