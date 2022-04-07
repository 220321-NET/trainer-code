using Microsoft.AspNetCore.Mvc;
using BL;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly ISLBL _bl;
        public IssuesController(ISLBL bl)
        {
            _bl = bl;
        }
        
        // GET: api/<IssuesController>
        [HttpGet]
        public List<Issue> Get()
        {
            return _bl.GetIssues();
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

        // POST api/<IssuesController>
        [HttpPost]
        public ActionResult<Issue> Post([FromBody] Issue issueToCreate)
        {
            return Created("api/Issues", _bl.CreateIssue(issueToCreate));
        }

        // PUT api/<IssuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IssuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
