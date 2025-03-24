using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LABEYAT.src
{

    internal class Connectiondb
    {
        public static SqlConnection Conectar()
        {
            string connectionString = "SERVER=HP-PROBOOK\\BEOFALEJANDROSQL;DATABASE=LABEYAT;Integrated Security=True;Pooling=False;";
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                throw; // Lanza la excepción para que el llamador pueda manejarla
            }
        }
    }

}
