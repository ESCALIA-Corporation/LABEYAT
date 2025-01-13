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
    public partial class document4 : UserControl
    {
        public document4()
        {
            InitializeComponent();
        }

        public DataTable equpopropositoprueba()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[EquipoPropositoPrueba];"; // Cambia esto si necesitas filtrar o seleccionar columnas específicas
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

        private void document4_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = equpopropositoprueba();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
