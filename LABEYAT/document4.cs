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
    public partial class document4 : UserControl
    {
        public document4()
        {
            InitializeComponent();
        }

        private void LlenarComboBoxmarca()
        {
            try
            {
                ComboBox1.Items.Clear();
                string query = "SELECT IDMarca, Nombre FROM [dbo].[Marca];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComboBox1.Items.Add(new { IDMarca = reader.GetInt32(0), Nombre = reader.GetString(1) });
                }
                reader.Close();
                ComboBox1.ValueMember = "IDMarca";
                ComboBox1.DisplayMember = "Nombre";
            }
            catch
            {
            }
        }

        private void LlenarComboBoxModelo()
        {
            try
            {
                ComboBox2.Items.Clear();
                string query = "SELECT IDModelo, Descripcion FROM [dbo].[Modelo];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComboBox2.Items.Add(new { IDModelo = reader.GetInt32(0), Descripcion = reader.GetString(1) });
                }
                reader.Close();
                ComboBox2.ValueMember = "IDModelo";
                ComboBox2.DisplayMember = "Descripcion";
            }
            catch
            {
            }
        }

        public DataTable equpomedicion()
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

        private void document4_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = equpomedicion();
                LlenarComboBoxmarca();
                LlenarComboBoxModelo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "INSERT INTO [dbo].[EquipoMedicion] (Referencia, Nombre, IDMarca, IDModelo, NumSerie, Imagen, Cantidad, IDUMedida, IDUbicacion, IDResponsable, IDEstatus, EstadoUso, EstadoMtto) VALUES (@referencia, @nombre, @idmarca, @idmodelo, @numserie, @imagen, @cantidad, @idumedida, @idubicacion, @idresponsable, @idestatus, @estadouso, @estadomtto);";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@referencia", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);
            int idMarcaSeleccionado = Convert.ToInt32(ComboBox1.SelectedValue);
            cmd.Parameters.Add("@idmarca", System.Data.SqlDbType.Int).Value = idMarcaSeleccionado;
            cmd.Parameters.AddWithValue("@idmodelo", "1");
            cmd.Parameters.AddWithValue("@numserie", TextBox3.Text);
            cmd.Parameters.AddWithValue("@imagen", TextBox6.Text);
            cmd.Parameters.AddWithValue("@cantidad", TextBox4.Text);
            cmd.Parameters.AddWithValue("@idumedida", "1");
            cmd.Parameters.AddWithValue("@idubicacion", "1");
            cmd.Parameters.AddWithValue("@idresponsable", "1");
            cmd.Parameters.AddWithValue("@idestatus", "1");
            cmd.Parameters.AddWithValue("@estadouso", "1");
            cmd.Parameters.AddWithValue("@estadomtto", "1");

            cmd.ExecuteNonQuery();
            MessageBox.Show("Equipo de Medicion agregado correctamente");
            dataGridView1.DataSource = equpomedicion();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedValue != null)
            {
                int idSeleccionado = (int)ComboBox1.SelectedValue;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox2.SelectedValue != null)
            {
                int idSeleccionado = (int)ComboBox2.SelectedValue;
            }
        }
    }
}
