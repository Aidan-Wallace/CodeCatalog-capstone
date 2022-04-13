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

        //AddSearchKeyword Method
        // [HttpPost()]
        // public ActionResult<SearchQuery> AddSearchKeyword(string keyword, int userId)
        // {
        //     SearchQuery addedKeyword = searchQueryDAO.AddSearchKeyword(keyword, userId);
        //     return Ok(addedKeyword);
        // }

        //GetExampleWithSearchKeyword Method
        // [HttpGet("{keyword}")]
        // public ActionResult<SearchQuery> GetExampleWithSearchKeyword(string keyword)
        // {
        //     SearchQuery returnedSearch = searchQueryDAO.GetExampleWithSearchKeyword(keyword);
        //     return Ok(returnedSearch);
        // }
    }
}
