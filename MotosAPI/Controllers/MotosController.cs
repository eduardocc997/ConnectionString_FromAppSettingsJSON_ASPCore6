using Microsoft.AspNetCore.Mvc;
using MotosAPI.Context;
using MotosAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotosController : ControllerBase
    {
        private readonly MotosDBContext context;

        public MotosController(MotosDBContext context)
        {
            this.context = context;
        }
        // GET: api/<MotosController>
        [HttpGet]
        public IEnumerable<Motos> Get()
        {
            return context.Motos.ToList();
        }

        // GET api/<MotosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MotosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MotosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
