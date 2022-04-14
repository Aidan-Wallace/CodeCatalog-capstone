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
    public class ScriptController : ControllerBase
    {
        private readonly IExampleDAO exampleDAO;
        public ScriptController(IExampleDAO _exampleDAO)
        {
            exampleDAO = _exampleDAO;
        }

        //GetExample Method  -----WORKS-----
        [HttpGet("{codeId}")]
        public ActionResult<CodeExample> FetchScript(int codeId)
        {
            CodeExample example = exampleDAO.FetchScript(codeId);
            return Ok(example);
        }

        //GetExample List Method  -----WORKS-----
        [HttpGet()]
        public ActionResult<List<CodeExample>> FetchAllScripts()
        {
            List<CodeExample> exampleList = exampleDAO.FetchAllScripts();
            return Ok(exampleList);
        }
