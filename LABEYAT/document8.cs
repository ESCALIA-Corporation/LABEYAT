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
    public partial class document8 : UserControl
    {
        public document8()
        {
            InitializeComponent();
        }

        public DataTable cargarmarca()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[Marca];"; // Cambia esto si necesitas filtrar o seleccionar columnas específicas
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

        private void document8_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = cargarmarca();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "INSERT INTO [dbo].[Marca] (IDMarca, Nombre) VALUES (@idmarca, @nombre);";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idmarca", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Marca agregada correctamente");
            dataGridView1.DataSource = cargarmarca();
        }
    }
}
