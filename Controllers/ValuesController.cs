using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // Api que listara todos los registro de persona
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {

            //validacion si no hay data 
            if (false)
                return BadRequest("No existe infromación para mostrar");



            return Ok(
                    new Object[]
                    {
                        new { id = 1 , nombre =  "jeison", edad="2"},
                        new { id = 1 , nombre =  "cas", edad="3"},
                        new { id = 1 , nombre =  "guihasn", edad="2"}
                    }
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
