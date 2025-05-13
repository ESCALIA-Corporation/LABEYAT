using LABEYAT.src;
using LABEYAT.src.combobox;
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
    public partial class document2 : UserControl
    {

        public document2()
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

                var listaMarcas = new List<Marca>();

                while (reader.Read())
                {
                    listaMarcas.Add(new Marca(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                ComboBox1.DataSource = listaMarcas;
                ComboBox1.ValueMember = "IDMarca";
                ComboBox1.DisplayMember = "Nombre";
            }
            catch { }
        }

        private void LlenarComboBoxModelo()
        {
            try
            {
                ComboBox2.Items.Clear();
                string query = "SELECT IDModelo, Descripcion FROM [dbo].[Modelo];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                var listarModelo = new List<Modelo>();

                while (reader.Read())
                {
                    listarModelo.Add(new Modelo(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                ComboBox2.DataSource = listarModelo;
                ComboBox2.ValueMember = "IDModelo";
                ComboBox2.DisplayMember = "Nombre";
            }
            catch { }
        }

        private void LlenarComboBoxResponsable()
        {
            try
            {
                ComboBox5.Items.Clear();
                string query = "SELECT IDResponsable, Nombre FROM [dbo].[Responsable];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                var listarresponsable = new List<Responsable>();

                while (reader.Read())
                {
                    listarresponsable.Add(new Responsable(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                ComboBox5.DataSource = listarresponsable;
                ComboBox5.ValueMember = "IDResponsable";
                ComboBox5.DisplayMember = "Nombre";
            }
            catch { }
        }

        private void LlenarComboBoxEstatus()
        {
            try
            {
                ComboBox7.Items.Clear();
                string query = "SELECT IDEstatus, Descripcion FROM [dbo].[Estatus];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                var listareststus = new List<Estatus>();

                while (reader.Read())
                {
                    listareststus.Add(new Estatus(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                ComboBox7.DataSource = listareststus;
                ComboBox7.ValueMember = "IDEstatus";
                ComboBox7.DisplayMember = "Nombre";
            }
            catch { }
        }

        private void LlenarComboBoxinmueble()
        {
            ComboBox13.Items.Clear();

            ComboBox13.Items.Add("Advance");
            ComboBox13.Items.Add("Aprove");
            ComboBox13.Items.Add("Cedar");
            ComboBox13.Items.Add("Empire");
            ComboBox13.Items.Add("Hioki");

            ComboBox13.SelectedIndex = 0;
        }

        public DataTable CargarEquipooficina()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM [dbo].[EquipoOficina];";

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
        }

        private void document2_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarComboBoxinmueble();
                LlenarComboBoxResponsable();
                LlenarComboBoxEstatus();
                LlenarComboBoxmarca();
                LlenarComboBoxModelo();
                dataGridView1.DataSource = CargarEquipooficina();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos, vuelva a intentarlo mas tarde: {ex.Message}");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Connectiondb.Conectar())
                {
                    string query = "INSERT INTO [dbo].[EquipoOficina] (IDNumero, Nomenclatura, Inmueble, IDMarca, IDModelo, NumSerie, Cantidad, Observaciones, FechaBaja, IDResponsable, IDEstatus) VALUES (@idnumero, @nomenclatura, @inmueble, @idmarca, @idmodelo, @numSerie, @cantidad, @observaciones, @fechaBaja, @idresponsable, @idestatus);";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idnumero", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@nomenclatura", TextBox2.Text);

                        cmd.Parameters.AddWithValue("@inmueble", ComboBox13.SelectedItem.ToString());

                        if (ComboBox1.SelectedValue != null && int.TryParse(ComboBox1.SelectedValue.ToString(), out int idMarcaSeleccionado))
                        {
                            cmd.Parameters.Add("@idmarca", SqlDbType.Int).Value = idMarcaSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox2.SelectedValue != null && int.TryParse(ComboBox2.SelectedValue.ToString(), out int idModeloSeleccionado))
                        {
                            cmd.Parameters.Add("@idmodelo", SqlDbType.Int).Value = idModeloSeleccionado;
                        }
                        else
                        {
                            return;
                        }
                        cmd.Parameters.AddWithValue("@numSerie", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@cantidad", TextBox4.Text);
                        cmd.Parameters.AddWithValue("@observaciones", TextBox6.Text);

                        cmd.Parameters.AddWithValue("@fechaBaja", DateTimePicker1.Value.ToString("yyyy-MM-dd"));

                        if (ComboBox5.SelectedValue != null && int.TryParse(ComboBox5.SelectedValue.ToString(), out int idResponsableSeleccionado))
                        {
                            cmd.Parameters.Add("@idresponsable", SqlDbType.Int).Value = idResponsableSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox7.SelectedValue != null && int.TryParse(ComboBox7.SelectedValue.ToString(), out int idEstatusSeleccionado))
                        {
                            cmd.Parameters.Add("@idestatus", SqlDbType.Int).Value = idEstatusSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Equipo de Oficina agregado correctamente.");
                        TextBox1.Clear();
                        TextBox2.Clear();
                        TextBox3.Clear();
                        TextBox4.Clear();
                        TextBox6.Clear();
                        dataGridView1.DataSource = CargarEquipooficina();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el equipo: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TextBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                TextBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                TextBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            catch
            {
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
            TextBox6.Clear();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedItem != null)
            {
                Marca marcaSeleccionada = (Marca)ComboBox1.SelectedItem;
                int idSeleccionado = marcaSeleccionada.IDMarca;
                string nombreSeleccionado = marcaSeleccionada.Nombre;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox2.SelectedItem != null)
            {
                Modelo modeloseleccionado = (Modelo)ComboBox2.SelectedItem;
                int idSeleccionado = modeloseleccionado.IDModelo;
                string nombreSeleccionado = modeloseleccionado.Nombre;
            }
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[EquipoOficina] WHERE IDNumero = @idnumero;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idnumero", TextBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
                TextBox1.Clear();
                TextBox2.Clear();
                TextBox3.Clear();
                TextBox4.Clear();
                TextBox6.Clear();
                MessageBox.Show("Responsable eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar responsable: {ex.Message}");
            }
            dataGridView1.DataSource = CargarEquipooficina();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Connectiondb.Conectar())
                {
                    string query = "UPDATE EquipoOficina SET Nomenclatura = @nomenclatura, Inmueble =  @inmueble, IDMarca = @idmarca, IDModelo = @idmodelo, NumSerie = @numSerie, Cantidad = @cantidad, Observaciones = @observaciones, FechaBaja = @fechaBaja, IDResponsable = @idresponsable, IDEstatus = @idestatus WHERE @idnumero = IDNumero";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idnumero", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@nomenclatura", TextBox2.Text);

                        cmd.Parameters.AddWithValue("@inmueble", ComboBox13.SelectedItem.ToString());

                        if (ComboBox1.SelectedValue != null && int.TryParse(ComboBox1.SelectedValue.ToString(), out int idMarcaSeleccionado))
                        {
                            cmd.Parameters.Add("@idmarca", SqlDbType.Int).Value = idMarcaSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox2.SelectedValue != null && int.TryParse(ComboBox2.SelectedValue.ToString(), out int idModeloSeleccionado))
                        {
                            cmd.Parameters.Add("@idmodelo", SqlDbType.Int).Value = idModeloSeleccionado;
                        }
                        else
                        {
                            return;
                        }
                        cmd.Parameters.AddWithValue("@numSerie", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@cantidad", TextBox4.Text);
                        cmd.Parameters.AddWithValue("@observaciones", TextBox6.Text);

                        cmd.Parameters.AddWithValue("@fechaBaja", DateTimePicker1.Value.ToString("yyyy-MM-dd"));

                        if (ComboBox5.SelectedValue != null && int.TryParse(ComboBox5.SelectedValue.ToString(), out int idResponsableSeleccionado))
                        {
                            cmd.Parameters.Add("@idresponsable", SqlDbType.Int).Value = idResponsableSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox7.SelectedValue != null && int.TryParse(ComboBox7.SelectedValue.ToString(), out int idEstatusSeleccionado))
                        {
                            cmd.Parameters.Add("@idestatus", SqlDbType.Int).Value = idEstatusSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Equipo de Oficina agregado correctamente.");
                        TextBox1.Clear();
                        TextBox2.Clear();
                        TextBox3.Clear();
                        TextBox4.Clear();
                        TextBox6.Clear();
                        dataGridView1.DataSource = CargarEquipooficina();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el equipo: {ex.Message}");
            }
        }
    }
}