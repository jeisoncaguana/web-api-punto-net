using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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
            //Crea instancia a bd
            SqlServerConection oCnn = new SqlServerConection();

            //crea conexion a bd 
            oCnn.open();

            //ejecuta procedimeinto almacenado en sql server 
            SqlDataReader odr = oCnn.ejecutarSQL("exec [dbo].[listarPersona]");


            //variable de retorno
            Object[] myObjArray = new Object[100];


            // lectura de procedimineto almaccenad odr.Read()
            for (int i = 0;  odr.Read() ; i++) 
            {
                myObjArray[i] = new {
                    nombre   = odr["nombre"].ToString(),
                    apellido = odr["apellido"].ToString(),
                    edad     = odr["edad"].ToString()
                };
                 
            }

            //retorno de unformacion 
            return Ok(myObjArray.Where(c => c != null));
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //Crea instancia a bd
            SqlServerConection oCnn = new SqlServerConection();

            //crea conexion a bd 
            oCnn.open();

            //ejecuta procedimeinto almacenado en sql server 
            SqlDataReader odr = oCnn.ejecutarSQL("exec [dbo].[buscarPersona] '12' ");


            //variable de retorno
            Object[] myObjArray = new Object[100];


            // lectura de procedimineto almaccenad odr.Read()
            for (int i = 0; odr.Read(); i++)
            {
                 myObjArray[i] = new
                {
                    nombre = odr["nombre"].ToString(),
                    apellido = odr["apellido"].ToString(),
                    edad = odr["edad"].ToString()
                };

            }

            //retorno de unformacion 
            return Ok(myObjArray.Where(c => c != null));

        }

        

    }
}
