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
    public partial class document2 : UserControl
    {

        public document2()
        {
            InitializeComponent();
        }


        public DataTable CargarEquipooficina()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[EquipoOficina];"; // Cambia esto si necesitas filtrar o seleccionar columnas específicas

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

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Aquí puedes manejar el clic en las celdas del DataGridView
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                MessageBox.Show($"Has hecho clic en la celda: {cellValue}");
            }
        }

        private void document2_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = CargarEquipooficina();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //TODO: Fix them because they are not working correctly
            Connectiondb.Conectar();
            string query = "INSERT INTO [dbo].[EquipoOficina] (IDNumero, Nomenclatura, Inmueble, IDMarca, IDModelo, NumSerie, Cantidad, Observaciones, FechaBaja, IDResponsable, IDEstatus) VALUES (@idnumero, @nomenclatura, @inmueble, @idmarca, @idmodelo, @numSerie, @cantidad, @observaciones, @fechaBaja, @idresponsable, @idestatus);";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idnumero", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nomenclatura", TextBox2.Text);
            cmd.Parameters.AddWithValue("@inmueble", ComboBox13.Text);
            cmd.Parameters.AddWithValue("@idmarca", ComboBox1.Text);
            cmd.Parameters.AddWithValue("@idmodelo", ComboBox2.Text);
            cmd.Parameters.AddWithValue("@numSerie", TextBox3.Text);
            cmd.Parameters.AddWithValue("@cantidad", TextBox4.Text);
            cmd.Parameters.AddWithValue("@observaciones", TextBox6.Text);
            cmd.Parameters.AddWithValue("@fechaBaja", DateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@idresponsable", ComboBox5.Text);
            cmd.Parameters.AddWithValue("@idestatus", ComboBox7.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Departamento agregado correctamente");
            dataGridView1.DataSource = CargarEquipooficina();
        }
    }
}
