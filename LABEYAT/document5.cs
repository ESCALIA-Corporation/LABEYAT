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

        private void Button2_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "UPDATE [dbo].[Responsable] SET Nombre = @nombre, Apellido_Paterno = @apellidopaterno, Apellido_Materno = @apellidomaterno WHERE IDResponsable = @idresponsable;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idresponsable", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);
            cmd.Parameters.AddWithValue("@apellidopaterno", TextBox4.Text);
            cmd.Parameters.AddWithValue("@apellidomaterno", TextBox3.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Responsable actualizado correctamente");
            dataGridView1.DataSource = cargarresponsable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TextBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                TextBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }catch
            {
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[Responsable] WHERE IDResponsable = @idresponsable;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idresponsable", TextBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Responsable eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar responsable: {ex.Message}");
            }
            dataGridView1.DataSource = cargarresponsable();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Connectiondb.Conectar())
            {
                string query;
                SqlCommand cmd = new SqlCommand();

                if (int.TryParse(TextBox1.Text, out int id))
                {
                    query = "SELECT * FROM [dbo].[Responsable] WHERE IDResponsable = @idresponsable;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idresponsable", id);
                }
                else
                {
                    query = "SELECT * FROM [dbo].[Responsable] WHERE Nombre LIKE @nombre;";
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
