using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Capstone.DAO.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("search")]
    [ApiController]
    public class SearchQueryController : ControllerBase
    {
        private readonly ISearchQueryDAO searchQueryDAO;
        public SearchQueryController(ISearchQueryDAO searchQueryDAO)
        {
            this.searchQueryDAO = searchQueryDAO;
        }

        //SearchByKeyword Method
        [HttpGet("{keyword}")]
        public ActionResult<List<CodeExample>> SearchByKeyword(string keyword)
        {
            List<CodeExample> exampleList = searchQueryDAO.SearchByKeyword(keyword);
            return Ok(exampleList);
        }

    }
}
