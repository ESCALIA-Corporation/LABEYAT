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
            try
            {
                TextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {
            }
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

        private void Button2_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "UPDATE [dbo].[Marca] SET Nombre = @nombre WHERE IDMarca = @idmarca;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idmarca", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Marca actualizada correctamente");
            dataGridView1.DataSource = cargarmarca();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[Marca] WHERE IDMarca = @idmarca;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idmarca", TextBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Marca eliminada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la marca por errores en clave foranea: {ex.Message}");
            }

            dataGridView1.DataSource = cargarmarca();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Connectiondb.Conectar())
            {
                string query;
                SqlCommand cmd = new SqlCommand();

                if (int.TryParse(TextBox1.Text, out int id))
                {
                    query = "SELECT * FROM [dbo].[Marca] WHERE IDMarca = @idmarca;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idmarca", id);
                }
                else
                {
                    query = "SELECT * FROM [dbo].[Marca] WHERE Nombre LIKE @nombre;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", "%" + TextBox1.Text + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }

        }
    }
}
