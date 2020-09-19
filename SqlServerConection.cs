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




        public SqlDataReader ejecutarStoreProcedute(string nameStoreProcedure, object[] values)
        {
            try
            {
                string Comando = " declare @msg AS VARCHAR(100); exec " + nameStoreProcedure + " ";
                for (int i = 0; i < values.Length; i++)
                {

                    if (i != values.Length - 1)
                    {
                        if (values[i].GetType().ToString() != "System.DBNull")
                            Comando += "'" + values[i] + "',";
                        else
                            Comando += "NULL,";
                    }
                    else
                        if (values[i].GetType().ToString() != "System.DBNull")
                        Comando += "'" + values[i] + "',@msg OUTPUT; select @msg ";
                    else
                        Comando += "" + values[i] + ",@msg OUTPUT; select @msg ";
                }

                cmd = new SqlCommand(Comando, oCnn);
                dra = cmd.ExecuteReader();
                return dra;
            }
            catch (Exception er)
            {
                return null;
            }

        }

        public SqlDataReader select(string sql) {

            try
            {
                cmd = new SqlCommand(sql, oCnn);
                dra = cmd.ExecuteReader();
                return dra;

            }
            catch (Exception)
            {

            return  null;
            }
        }


        // Ejecuta procedimientos almacenados en sql server
        public string ejecutarStoreProcedute(string nameStoreProcedure, object[] values)
        {
            try
            {
                string Comando = " declare @msg AS VARCHAR(100); exec " + nameStoreProcedure + " ";
                for (int i = 0; i < values.Length; i++)
                {

                    if (i != values.Length - 1)
                    {
                        if (values[i].GetType().ToString() != "System.DBNull")
                            Comando += "'" + values[i] + "',";
                        else
                            Comando += "NULL,";
                    }
                    else
                        if (values[i].GetType().ToString() != "System.DBNull")
                        Comando += "'" + values[i] + "',@msg OUTPUT; select @msg ";
                    else
                        Comando += "" + values[i] + ",@msg OUTPUT; select @msg ";
                }

                cmd = new SqlCommand(Comando, oCnn);
                dra = cmd.ExecuteReader();
                try
                {
                    dra.Read();
                    string mensaje = dra[0].ToString();
                    return mensaje;
                }
                catch
                {


                }
            }
            catch { }
            finally
            {
                dra.Close();
            }
            return "ERROR";
        }


    }
}
