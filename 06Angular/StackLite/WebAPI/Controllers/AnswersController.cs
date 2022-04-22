using Microsoft.AspNetCore.Mvc;
using BL;
using Models;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly ISLBL _bl;
        private IMemoryCache _cache;
        public AnswersController(ISLBL bl, IMemoryCache cache)
        {
            _bl = bl;
            _cache = cache;
        }
        
        [HttpPost]
        public async Task<Answer> PostAsync(Answer answerToCreate)
        {   
            return await _bl.AddAnswerAsync(answerToCreate);
        }
    }
}
