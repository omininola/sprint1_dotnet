using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikeLot : ControllerBase
    {
        // GET: api/<MotorbikeLot>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MotorbikeLot>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MotorbikeLot>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MotorbikeLot>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotorbikeLot>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
