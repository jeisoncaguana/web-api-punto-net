using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class webApiPeronas : ControllerBase
    {


        // Api que listara todos los registro de persona
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(
                    new Object[]
                    {
                        new { id = 1 , nombre =  "jeison", edad="2"},
                        new { id = 1 , nombre =  "cas", edad="3"},
                        new { id = 1 , nombre =  "guihasn", edad="2"}
                    }
                );
        }





    }
}
