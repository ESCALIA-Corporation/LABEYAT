using LABEYAT.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABEYAT
{
    public partial class document5 : UserControl
    {
        public document5()
        {
            InitializeComponent();
        }

        public DataTable cargarresponsable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[Responsable];"; // Cambia esto si necesitas filtrar o seleccionar columnas específicas
            using (SqlConnection connection = Connectiondb.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private void document5_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = cargarresponsable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "INSERT INTO [dbo].[Responsable] (IDResponsable, Nombre, Apellido_Paterno, Apellido_Materno) VALUES (@idresponsable, @nombre, @apellidopaterno, @apellidomaterno);";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idresponsable", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);
            cmd.Parameters.AddWithValue("@apellidopaterno", TextBox4.Text);
            cmd.Parameters.AddWithValue("@apellidomaterno", TextBox3.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Departamento agregado correctamente");
            dataGridView1.DataSource = cargarresponsable();
        }
    }
}
