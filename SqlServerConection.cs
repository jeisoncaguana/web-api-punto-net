using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace webApi
{
    public class SqlServerConection
    {

        //
        public SqlConnection oCnn = new SqlConnection();
        private string cadenaConexion = "Data Source=LAPTOP-A5TPQC4E;Initial Catalog=test;Integrated Security=True";
        SqlCommand cmd;
        SqlDataReader dra = null;

        public SqlServerConection() { }

        public SqlServerConection(string cadenaConexion) {
            this.cadenaConexion = cadenaConexion;
        }


        public void open() {
            oCnn.ConnectionString = this.cadenaConexion;
            oCnn.Open();
        }

        public void close() {
            oCnn.Close();
        }




        public SqlDataReader ejecutarSQL(string sql) {
            try
            {
                cmd = new SqlCommand(sql, oCnn);
                dra = cmd.ExecuteReader();
                return dra;
            }
            catch (Exception e)
            {
                return null; 
            }
        }
    }
}
