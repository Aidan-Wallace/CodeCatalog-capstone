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

        //SearchQuery Method
        [HttpGet("{keyword}")]
        public ActionResult<SearchQuery> SearchQuery(string keyword)
        {
            SearchQuery returnedSearch = searchQueryDAO.SearchQuery(keyword);
            return Ok(returnedSearch);
        }
    }
}
