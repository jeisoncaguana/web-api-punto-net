using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

using webApi.Models;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class webApiPeronas : ControllerBase
    {
        // Api que listara todos los registro de persona
        // GET api/values   R = READ
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
                    nombre   = odr["respuesta"].ToString(),
                    apellido = odr["apellido"].ToString(),
                    edad     = odr["edad"].ToString()
                };
                 
            }

            //retorno de unformacion 
            return Ok(myObjArray.Where(c => c != null));
        }

        // GET api/values/5  R=READ BY ID
        [HttpGet("{filtro}")]
        public ActionResult Get(string filtro)
        {
            //Crea instancia a bd
            SqlServerConection oCnn = new SqlServerConection();

            //crea conexion a bd 
            oCnn.open();

            //ejecuta procedimeinto almacenado en sql server 
            SqlDataReader odr = oCnn.ejecutarSQL("exec [dbo].[buscarPersona] '"+filtro+"' ");


            //variable de retorno
            Object[] myObjArray = new Object[100];


            // lectura de procedimineto almaccenad odr.Read()
            for (int i = 0; odr.Read(); i++)
            {


                if (odr["respuesta"].ToString()  == "Existen resultados")
                {
                    myObjArray[i] = new
                    {
                        nombre = odr["nombre"].ToString(),
                        apellido = odr["apellido"].ToString(),
                        edad = odr["edad"].ToString()
                    };
                }
                else
                {
                    return Ok(new { resp = odr["respuesta"].ToString() });

                } 
            }

            return Ok(myObjArray.Where(c => c != null));
        }
      
        
        // POST api/values   C = CREATE
        [HttpPost]
        public ActionResult Post(Persona p)
        {
            //Crea instancia a bd
            SqlServerConection oCnn = new SqlServerConection();

            //crea conexion a bd 
            oCnn.open();

            //ejecuta procedimeinto almacenado en sql server 
            SqlDataReader odr = oCnn.ejecutarSQL("[dbo].[insertarPersona] '" + p.nombre + "','" + p.apellido + "','" + p.edad + "'");

            odr.Read();
            return Ok(new { resp = odr["respuesta"].ToString() });

        }



        // PUT api/values/5 U = UPDATE
        [HttpPut()]
        public ActionResult Put(Persona p)
        {

            //Crea instancia a bd
            SqlServerConection oCnn = new SqlServerConection();

            //crea conexion a bd 
            oCnn.open();

            //ejecuta procedimeinto almacenado en sql server 
            SqlDataReader odr = oCnn.ejecutarSQL("[dbo].[modificaPersona] '" + p.nombre + "','" + p.apellido + "','" + p.edad + "'");

            odr.Read();
            return Ok(new { resp = odr["respuesta"].ToString() });

        }

        // DELETE api/values/5
        [HttpDelete("{nombre}")]
        public ActionResult Delete(String nombre)
        {
            //Crea instancia a bd
            SqlServerConection oCnn = new SqlServerConection();

            //crea conexion a bd 
            oCnn.open();

            //ejecuta procedimeinto almacenado en sql server 
            SqlDataReader odr = oCnn.ejecutarSQL("[dbo].[eliminarPersona] '" + nombre + "'");

            odr.Read();
            return Ok(new { resp = odr["respuesta"].ToString() });

        }


    }

}
