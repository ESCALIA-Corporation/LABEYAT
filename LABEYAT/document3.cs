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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LABEYAT
{
    public partial class document3 : UserControl
    {
        public document3()
        {
            InitializeComponent();
        }
        public DataTable cargarequipomedicion()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[EquipoMedicion];"; // Cambia esto si necesitas filtrar o seleccionar columnas específicas

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
       

        private void document3_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = cargarequipomedicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Aquí puedes manejar el clic en las celdas del DataGridView
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                MessageBox.Show($"Has hecho clic en la celda: {cellValue}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //TODO: Fix them because they are not working correctly
            Connectiondb.Conectar();
            string query = "INSERT INTO [dbo].[EquipoMedicion] (Referencia, Nombre, IDMarca, IDModelo, NumSerie, Imagen, Cantidad, IDUMedida, IDUbicacion, IDResponsable, IDEstatus, EstadoUso, EstadoMtto)  VALUES (@referencia, @nombre, @idmarca, @idmodelo, @numSerie, @imagen, @cantidad, idumedida, @idubicacion, @idresponsable, @idestatus, @estadoUso, @estadoMtto);";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@referencia", textBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmd.Parameters.AddWithValue("@idmarca", textBox3.Text);
            cmd.Parameters.AddWithValue("@idmodelo", textBox4.Text);
            cmd.Parameters.AddWithValue("@numSerie", textBox5.Text);
            cmd.Parameters.AddWithValue("@imagen", textBox6.Text);
            cmd.Parameters.AddWithValue("@cantidad", textBox7.Text);
            cmd.Parameters.AddWithValue("@idumedida", textBox8.Text);
            cmd.Parameters.AddWithValue("@idubicacion", textBox9.Text);
            cmd.Parameters.AddWithValue("@idresponsable", textBox10.Text);
            cmd.Parameters.AddWithValue("@idestatus", textBox11.Text);
            cmd.Parameters.AddWithValue("@estadoUso", textBox12.Text);
            cmd.Parameters.AddWithValue("@estadoMtto", textBox13.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Departamento agregado correctamente");
            dataGridView1.DataSource = cargarequipomedicion();
        }
    }
}
