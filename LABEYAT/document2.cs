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
    }
}
