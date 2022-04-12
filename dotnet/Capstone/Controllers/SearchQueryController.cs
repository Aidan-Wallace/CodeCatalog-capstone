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
    public class SearchQueryController : ControllerBase
    {
        private readonly ISearchQueryDAO searchQueryDAO;
        public SearchQueryController(ISearchQueryDAO searchQueryDAO)
        {
            this.searchQueryDAO = searchQueryDAO;
        }

        //SearchQuery Method
        [HttpGet("{keyWord}")]
        public ActionResult<SearchQuery> SearchQuery(string keyWord)
        {
            SearchQuery returnedSearch = searchQueryDAO.SearchQuery(keyWord);
            return Ok(returnedSearch);
        }
    }
}