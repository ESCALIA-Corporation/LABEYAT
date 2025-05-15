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
    public partial class document9 : UserControl
    {
        public document9()
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

        public DataTable cargardepartamento()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[Departamento];"; // Cambia esto si necesitas filtrar o seleccionar columnas específicas
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

        public DataTable cargarmodelo()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[Modelo];"; // Cambia esto si necesitas filtrar o seleccionar columnas específicas
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

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void document9_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = cargarnormas();
                dataGridView2.DataSource = cargardepartamento();
                dataGridView4.DataSource = cargarresponsable();
                dataGridView3.DataSource = cargarmarca();
                dataGridView5.DataSource = cargarmodelo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "INSERT INTO [dbo].[Departamento] (IDDepto, Nombre) VALUES (@iddepto, @nombre);";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@iddepto", textBox5.Text);
                cmd.Parameters.AddWithValue("@nombre", textBox3.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Departamento agregado correctamente");
                textBox5.Clear();
                textBox3.Clear();
                dataGridView2.DataSource = cargardepartamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el departamento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "UPDATE [dbo].[Departamento] SET Nombre = @nombre WHERE IDDepto = @iddepto;";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@iddepto", textBox5.Text);
                cmd.Parameters.AddWithValue("@nombre", textBox3.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Departamento actualizado correctamente");
                textBox5.Clear();
                textBox3.Clear();
                dataGridView2.DataSource = cargardepartamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el departamento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[Departamento] WHERE IDDepto = @iddepto;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@iddepto", textBox5.Text);
            try
            {
                cmd.ExecuteNonQuery();
                textBox5.Clear();
                textBox3.Clear();
                MessageBox.Show("Marca eliminada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la marca por errores en clave foranea: {ex.Message}");
            }

            MessageBox.Show("Departamento eliminado correctamente");
            dataGridView2.DataSource = cargardepartamento();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox3.Clear();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = Connectiondb.Conectar())
            {
                string query;
                SqlCommand cmd = new SqlCommand();

                query = "SELECT * FROM [dbo].[Departamento] WHERE Nombre LIKE @nombre;";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", "%" + textBox3.Text + "%");
                textBox3.Clear();
                textBox5.Clear(); // Considera si realmente quieres limpiar textBox5 aquí

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView2.DataSource = dt;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "INSERT INTO [dbo].[Responsable] (IDResponsable, Nombre, Apellido_Paterno, Apellido_Materno) VALUES (@idresponsable, @nombre, @apellidopaterno, @apellidomaterno);";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@idresponsable", textBox12.Text);
                cmd.Parameters.AddWithValue("@nombre", textBox11.Text);
                cmd.Parameters.AddWithValue("@apellidopaterno", textBox9.Text);
                cmd.Parameters.AddWithValue("@apellidomaterno", textBox10.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Departamento agregado correctamente");
                textBox12.Clear();
                textBox11.Clear();
                textBox10.Clear();
                textBox9.Clear();
                dataGridView4.DataSource = cargarresponsable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el responsable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox12.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                textBox11.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                textBox9.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                textBox10.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            }
            catch
            {
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "UPDATE [dbo].[Responsable] SET Nombre = @nombre, Apellido_Paterno = @apellidopaterno, Apellido_Materno = @apellidomaterno WHERE IDResponsable = @idresponsable;";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@idresponsable", textBox12.Text);
                cmd.Parameters.AddWithValue("@nombre", textBox11.Text);
                cmd.Parameters.AddWithValue("@apellidopaterno", textBox9.Text);
                cmd.Parameters.AddWithValue("@apellidomaterno", textBox10.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Departamento agregado correctamente");
                textBox12.Clear();
                textBox11.Clear();
                textBox10.Clear();
                textBox9.Clear();
                dataGridView4.DataSource = cargarresponsable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el responsable: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[Responsable] WHERE IDResponsable = @idresponsable;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idresponsable", textBox12.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Responsable eliminado correctamente");
                textBox12.Clear();
                textBox11.Clear();
                textBox10.Clear();
                textBox9.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar responsable: {ex.Message}");
            }
            dataGridView4.DataSource = cargarresponsable();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Connectiondb.Conectar())
            {
                string query;
                SqlCommand cmd = new SqlCommand();

                if (int.TryParse(textBox12.Text, out int id))
                {
                    query = "SELECT * FROM [dbo].[Responsable] WHERE IDResponsable = @idresponsable;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idresponsable", id);
                    textBox12.Clear();
                    textBox11.Clear();
                    textBox10.Clear();
                    textBox9.Clear();
                }
                else
                {
                    query = "SELECT * FROM [dbo].[Responsable] WHERE Nombre LIKE @nombre;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", "%" + textBox12.Text + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView4.DataSource = dt;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "INSERT INTO [dbo].[Marca] (IDMarca, Nombre) VALUES (@idmarca, @nombre);";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@idmarca", textBox8.Text);
                cmd.Parameters.AddWithValue("@nombre", textBox7.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Marca agregada correctamente");
                textBox8.Clear();
                textBox7.Clear();
                dataGridView3.DataSource = cargarmarca();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "UPDATE [dbo].[Marca] SET Nombre = @nombre WHERE IDMarca = @idmarca;";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@idmarca", textBox8.Text);
                cmd.Parameters.AddWithValue("@nombre", textBox7.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Marca actualizada correctamente");
                textBox8.Clear();
                textBox7.Clear();
                dataGridView3.DataSource = cargarmarca();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[Marca] WHERE IDMarca = @idmarca;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idmarca", textBox8.Text);
            try
            {
                cmd.ExecuteNonQuery();
                textBox8.Clear();
                textBox7.Clear();
                MessageBox.Show("Marca eliminada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la marca por errores en clave foranea: {ex.Message}");
            }

            dataGridView3.DataSource = cargarmarca();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox7.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Connectiondb.Conectar())
            {
                string query;
                SqlCommand cmd = new SqlCommand();

                if (int.TryParse(textBox8.Text, out int id))
                {
                    query = "SELECT * FROM [dbo].[Marca] WHERE IDMarca = @idmarca;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idmarca", id);
                    textBox8.Clear();
                    textBox7.Clear();
                }
                else
                {
                    query = "SELECT * FROM [dbo].[Marca] WHERE Nombre LIKE @nombre;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", "%" + textBox8.Text + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView3.DataSource = dt;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox8.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                textBox7.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "INSERT INTO [dbo].[Normas] (IDNorma, Nombre, Descripcion) VALUES (@idnorma, @nombre, @descripcion);";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@idnorma", TextBox1.Text);
                cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);
                cmd.Parameters.AddWithValue("@descripcion", TextBox4.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Norma agregada correctamente");
                TextBox1.Clear();
                TextBox2.Clear();
                TextBox4.Clear();
                dataGridView1.DataSource = cargarnormas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la norma: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "UPDATE [dbo].[Normas] SET Nombre = @nombre, Descripcion = @descripcion WHERE IDNorma = @idnorma;";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@idnorma", TextBox1.Text);
                cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);
                cmd.Parameters.AddWithValue("@descripcion", TextBox4.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Norma actualizada correctamente");
                TextBox1.Clear();
                TextBox2.Clear();
                TextBox4.Clear();
                dataGridView1.DataSource = cargarnormas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la norma: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[Normas] WHERE IDNorma = @idnorma;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idnorma", TextBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Norma eliminada correctamente");
                TextBox1.Clear();
                TextBox2.Clear();
                TextBox4.Clear();
                dataGridView1.DataSource = cargarnormas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la norma: {ex.Message}");
            }
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox4.Clear();
        }

        private void Button5_Click_1(object sender, EventArgs e)
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
                    TextBox1.Clear();
                    TextBox2.Clear();
                    TextBox4.Clear();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TextBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "INSERT INTO [dbo].[Modelo] (IDModelo, Descripcion) VALUES (@idmodelo, @descripcion);";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@idmodelo", textBox13.Text);
                cmd.Parameters.AddWithValue("@descripcion", textBox6.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Marca agregada correctamente");
                textBox13.Clear();
                textBox6.Clear();
                dataGridView5.DataSource = cargarmodelo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el modelo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox13.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
                textBox6.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                Connectiondb.Conectar();
                string query = "UPDATE [dbo].[Modelo] SET Descripcion = @descripcion WHERE IDModelo = @idmodelo;";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                cmd.Parameters.AddWithValue("@idmodelo", textBox13.Text);
                cmd.Parameters.AddWithValue("@descripcion", textBox6.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Marca agregada correctamente");
                textBox13.Clear();
                textBox6.Clear();
                dataGridView5.DataSource = cargarmodelo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el modelo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[Modelo] WHERE IDModelo = @idmodelo;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idmarca", textBox13.Text);
            try
            {
                cmd.ExecuteNonQuery();
                textBox13.Clear();
                textBox6.Clear();
                MessageBox.Show("Marca eliminada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la marca por errores en clave foranea: {ex.Message}");
            }

            dataGridView5.DataSource = cargarmodelo();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
            textBox6.Clear();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Connectiondb.Conectar())
            {
                string query;
                SqlCommand cmd = new SqlCommand();

                if (int.TryParse(textBox13.Text, out int id))
                {
                    query = "SELECT * FROM [dbo].[Modelo] WHERE IDModelo = @idmodelo;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idmodelo", id);
                    textBox13.Clear();
                    textBox6.Clear();
                }
                else
                {
                    query = "SELECT * FROM [dbo].[Modelo] WHERE Descripcion LIKE @descripcion;";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@descripcion", "%" + textBox13.Text + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView5.DataSource = dt;
            }

        }
    }
}
