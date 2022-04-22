using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly ISLBL _bl;
        private IMemoryCache _cache;
        public IssuesController(ISLBL bl, IMemoryCache cache)
        {
            _bl = bl;
            _cache = cache;
        }
        
        // GET: api/<IssuesController>
        [HttpGet]
        public async Task<List<Issue>> GetAsync()
        {
            List<Issue> issues = new List<Issue>();
            if(_cache.TryGetValue<List<Issue>>("AllIssues", out issues))
            {
                return issues;
            }
            else
            {
                issues = await _bl.GetIssuesAsync();
                TimeSpan expiration = new TimeSpan(0, 1, 0);
                _cache.Set("AllIssues", issues, expiration);
                return issues;
            }
        }

        [HttpGet("answers")]
        public List<Issue> GetIssuesWithAnswers()
        {
            return _bl.GetIssuesWithAnswers();
        }

        // GET api/<IssuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Issue> Get(int id)
        {
            Issue? issue = _bl.GetIssueById(id);
            if(issue != null)
            {
                return Ok(issue);
            }
            return NoContent();
        }

        //GET api/<IssuesController>/search?searchParam=string
        [HttpGet("search")]
        public async Task<List<Issue>> SearchAsync(string searchParam)
        {
            return await _bl.SearchIssueAsync(searchParam);
        }

        // POST api/<IssuesController>
        [HttpPost]
        public ActionResult<Issue> Post([FromBody] Issue issueToCreate)
        {
            //Create first
            Issue createdIssue = _bl.CreateIssue(issueToCreate);

            //check the cache, is there a cached all issues?
            //If so, update the cache
            List<Issue> issues = new List<Issue>();
            if(_cache.TryGetValue<List<Issue>>("AllIssues", out issues))
            {
                issues.Add(createdIssue);
                // _cache.Remove("Issues");
                _cache.Set("AllIssues", issues, new TimeSpan(0, 1, 0));
            }

            return Created("api/Issues", createdIssue);
        }

        // PUT api/<IssuesController>/close/6
        [HttpPut("close/{id}")]
        public ActionResult CloseIssue(int id)
        {
            Issue? issue = _bl.GetIssueById(id);
            if(issue != null)
            {
                _bl.CloseIssue(issue);
                return Ok();
            }
            else
            {
                return BadRequest("Question with the particular id has not been found");
            }
        }

        // DELETE api/<IssuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
