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

        //GetExample by Keyword Method  -----WORKS-----
        [HttpGet("search/{keyword}")]
        public ActionResult<List<CodeExample>> SearchByKeyword(string keyword)
        {
            List<CodeExample> exampleList = exampleDAO.SearchByKeyword(keyword);
            return Ok(exampleList);
        }

        //Get all examples created by this specific user   -----WORKS-----
        [HttpGet("user-example/{userId}")]
        //[Authorize(Roles = "user")]
        public ActionResult<List<CodeExample>> GetExamplesByUser(int userId)
        {
            List<CodeExample> exampleList = exampleDAO.GetExamplesByUser(userId);
            return Ok(exampleList);
        }

        //GetExample List Method  -----WORKS-----
        [HttpGet()]
        public ActionResult<List<CodeExample>> GetExamples()
        {
            List<CodeExample> exampleList = exampleDAO.GetExamples();
            return Ok(exampleList);
        }

        //AddExample Method -----WORKS-----
        [HttpPost("{userId}")] //we'll probably have to add a user id here but we can figure it out later, will also have to add a join to our sql script to account for userid in the model
        public ActionResult<CodeExample> AddExample(CodeExample newExample, int userId)
        {
            CodeExample newExampleCode = exampleDAO.AddExample(newExample, userId);
            return Ok(newExampleCode);
        }

        //AdminGetsListByStatus Method   -----WORKS-----
        [HttpGet("status/{submissionStatus}")]
        public ActionResult<List<CodeExample>> GetExamplesByStatus(int submissionStatus)
        {
            List<CodeExample> pendingExamples = exampleDAO.GetExamplesByStatus(submissionStatus);
            return Ok(pendingExamples);
        }

        //AdminApprovesSubmissionStatus  -----WORKS-----
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

        //Make public after AddedCode has been approved by Admin   -----WORKS-----
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

        //Update the programming language of the code snippet   -----WORKS-----
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

        //Updates the the initial list of generic code to be displayed to new users   -----WORKS-----
        [HttpPut("update-set-list/{codeId}")]
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

        //Gets the list of all code examples to be displayed to new users   -----WORKS-----
        [HttpGet("set-list")]
        public ActionResult<List<CodeExample>> GetGenericExampleList()
        {
            List<CodeExample> currentExamples = exampleDAO.GetGenericExampleList();
            return Ok(currentExamples);
        }
    }
}
