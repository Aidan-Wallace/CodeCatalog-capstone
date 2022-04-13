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

        //AddSearchKeyword Method
        [HttpPost()]
        public ActionResult<SearchQuery> AddSearchKeyword(string keyword)
        {
            SearchQuery addedKeyword = searchQueryDAO.AddSearchKeyword(keyword);
            return Ok(addedKeyword);
        }

        //GetExampleWithSearchKeyword Method
        [HttpGet("{keyword}")]
        public ActionResult<SearchQuery> GetExampleWithSearchKeyword(string keyword)
        {
            SearchQuery returnedSearch = searchQueryDAO.AddSearchKeyword(keyword);
            return Ok(returnedSearch);
        }
    }
}
