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
    public partial class document6 : UserControl
    {
        public document6()
        {
            InitializeComponent();
        }

        public DataTable cargarnormas()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[Normas];"; // Cambia esto si necesitas filtrar o seleccionar columnas específicas
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

        private void document6_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = cargarnormas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "INSERT INTO [dbo].[Normas] (IDNorma, Nombre, Descripcion) VALUES (@idnorma, @nombre, @descripcion);";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idnorma", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);
            cmd.Parameters.AddWithValue("@descripcion", TextBox4.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Norma agregada correctamente");
            dataGridView1.DataSource = cargarnormas();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "UPDATE [dbo].[Normas] SET Nombre = @nombre, Descripcion = @descripcion WHERE IDNorma = @idnorma;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idnorma", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);
            cmd.Parameters.AddWithValue("@descripcion", TextBox4.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Norma actualizada correctamente");
            dataGridView1.DataSource = cargarnormas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TextBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }catch
            {
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[Normas] WHERE IDNorma = @idnorma;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idnorma", TextBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Norma eliminada correctamente");
                dataGridView1.DataSource = cargarnormas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la norma: {ex.Message}");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
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
                    query = "SELECT * FROM [dbo].[Normas] WHERE IdNorma = @idnorma;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idnorma", id);
                }
                else
                {
                    query = "SELECT * FROM [dbo].[Normas] WHERE Nombre LIKE @nombre;";
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
