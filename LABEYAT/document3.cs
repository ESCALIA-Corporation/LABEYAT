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
    public partial class document3 : UserControl
    {
        public document3()
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

        private void LlenarComboBoxUnidaddeMedida()
        {
            try
            {
                ComboBox3.Items.Clear();
                string query = "SELECT IDUMedida, Descripcion FROM [dbo].[UnidadMedida];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                var listarunidadmedida = new List<UnidadMedida>();

                while (reader.Read())
                {
                    listarunidadmedida.Add(new UnidadMedida(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                ComboBox3.DataSource = listarunidadmedida;
                ComboBox3.ValueMember = "IDUMedida";
                ComboBox3.DisplayMember = "Nombre";
            }
            catch { }
        }


        private void LlenarComboBoxMantenimineto()
        {
            ComboBox13.Items.Clear();

            ComboBox13.Items.Add("Activo");
            ComboBox13.Items.Add("Inactivo");
            ComboBox13.Items.Add("En Mantenimiento");
            ComboBox13.Items.Add("Baja");

            ComboBox13.SelectedIndex = 0;
        }

        private void LlenarComboBoxEstadoUso()
        {
            ComboBox7.Items.Clear();

            ComboBox7.Items.Add("En Uso");
            ComboBox7.Items.Add("Disponible");
            ComboBox7.Items.Add("Reservado");
            ComboBox7.Items.Add("Dañado");

            ComboBox7.SelectedIndex = 0;
        }

        private void LlenarComboBoxUbicacion()
        {
            try
            {
                ComboBox4.Items.Clear();
                string query = "SELECT IDUbicacion, Descripcion FROM [dbo].[UbicacionEquipo];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                var listarubicacionequipo = new List<UbicacionEquipo>();

                while (reader.Read())
                {
                    listarubicacionequipo.Add(new UbicacionEquipo(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                ComboBox4.DataSource = listarubicacionequipo;
                ComboBox4.ValueMember = "IDUbicacion";
                ComboBox4.DisplayMember = "Nombre";
            }
            catch { }
        }

        private void LlenarComboBoxResponsable()
        {
            try
            {
                ComboBox6.Items.Clear();
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


        private void LlenarComboBoxDeoartamento()
        {
            try
            {
                ComboBox6.Items.Clear();
                string query = "SELECT IDDepto, Nombre FROM [dbo].[Departamento];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                var listardepartamento = new List<Departamento>();

                while (reader.Read())
                {
                    listardepartamento.Add(new Departamento(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                ComboBox6.DataSource = listardepartamento;
                ComboBox6.ValueMember = "IDDepto";
                ComboBox6.DisplayMember = "Nombre";
            }
            catch { }
        }


        private void LlenarCheckedListBoxNormas()
        {
            try
            {
                CheckedListBox1.Items.Clear();
                string query = "SELECT Nombre FROM [dbo].[Normas];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CheckedListBox1.Items.Add(reader["Nombre"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Normas en el CheckedListBox: {ex.Message}");
            }
        }

        public DataTable cargarequipomedicion()
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
       

        private void document3_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarCheckedListBoxNormas();
                LlenarComboBoxmarca();
                LlenarComboBoxModelo();
                LlenarComboBoxUnidaddeMedida();
                LlenarComboBoxUbicacion();
                LlenarComboBoxResponsable();
                LlenarComboBoxMantenimineto();
                LlenarComboBoxDeoartamento();
                LlenarComboBoxEstadoUso();
                dataGridView1.DataSource = cargarequipomedicion();
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
                TextBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                TextBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Connectiondb.Conectar())
                {
                    string query = "INSERT INTO [dbo].[EquipoPropositoPrueba] (IDMaquinaria, NombreEquipo, IDMarca, IDModelo, NumSerie, Cantidad, IDUMedida, IDUbicacion, IDResponsable, IDDepto, EstadoUso, EstadoMtto) VALUES (@idmaquinaria, @nombre, @idmarca, @idmodelo, @numserie, @cantidad, @idumedida, @idubicacion, @idresponsable, @iddepto, @estadouso, @estadomtto);";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idmaquinaria", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);

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

                        cmd.Parameters.AddWithValue("@numserie", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@cantidad", TextBox4.Text);

                        if (ComboBox3.SelectedValue != null && int.TryParse(ComboBox3.SelectedValue.ToString(), out int idUnidadMedidaSeleccionado))
                        {
                            cmd.Parameters.Add("@idumedida", SqlDbType.Int).Value = idUnidadMedidaSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox4.SelectedValue != null && int.TryParse(ComboBox4.SelectedValue.ToString(), out int idUbicacionEquipoSeleccionado))
                        {
                            cmd.Parameters.Add("@idubicacion", SqlDbType.Int).Value = idUbicacionEquipoSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox5.SelectedValue != null && int.TryParse(ComboBox5.SelectedValue.ToString(), out int idResponsableSeleccionado))
                        {
                            cmd.Parameters.Add("@idresponsable", SqlDbType.Int).Value = idResponsableSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox6.SelectedValue != null && int.TryParse(ComboBox6.SelectedValue.ToString(), out int idEstatusSeleccionado))
                        {
                            cmd.Parameters.Add("@iddepto", SqlDbType.Int).Value = idEstatusSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        cmd.Parameters.AddWithValue("@estadouso", ComboBox7.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@estadomtto", ComboBox13.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Equipo de Medición agregado correctamente.");
                        TextBox1.Clear();
                        TextBox2.Clear();
                        TextBox3.Clear();
                        TextBox4.Clear();
                        dataGridView1.DataSource = cargarequipomedicion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el equipo: {ex.Message}");
            }
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

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Connectiondb.Conectar())
                {
                    string query = "UPDATE [dbo].[EquipoPropositoPrueba] SET NombreEquipo = @nombre, IDMarca = @idmarca, IDModelo = @idmodelo, NumSerie = @numserie, Cantidad = @cantidad, IDUMedida = @idumedida, IDUbicacion = @idubicacion, IDResponsable = @idresponsable, IDDepto =  @iddepto, EstadoUso = @estadouso, EstadoMtto = @estadomtto WHERE @idmaquinaria = IDMaquinaria;";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idmaquinaria", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@nombre", TextBox2.Text);

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

                        cmd.Parameters.AddWithValue("@numserie", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@cantidad", TextBox4.Text);

                        if (ComboBox3.SelectedValue != null && int.TryParse(ComboBox3.SelectedValue.ToString(), out int idUnidadMedidaSeleccionado))
                        {
                            cmd.Parameters.Add("@idumedida", SqlDbType.Int).Value = idUnidadMedidaSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox4.SelectedValue != null && int.TryParse(ComboBox4.SelectedValue.ToString(), out int idUbicacionEquipoSeleccionado))
                        {
                            cmd.Parameters.Add("@idubicacion", SqlDbType.Int).Value = idUbicacionEquipoSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox5.SelectedValue != null && int.TryParse(ComboBox5.SelectedValue.ToString(), out int idResponsableSeleccionado))
                        {
                            cmd.Parameters.Add("@idresponsable", SqlDbType.Int).Value = idResponsableSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox6.SelectedValue != null && int.TryParse(ComboBox6.SelectedValue.ToString(), out int idEstatusSeleccionado))
                        {
                            cmd.Parameters.Add("@iddepto", SqlDbType.Int).Value = idEstatusSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        cmd.Parameters.AddWithValue("@estadouso", ComboBox7.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@estadomtto", ComboBox13.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Equipo de Medición actualizado correctamente.");
                        TextBox1.Clear();
                        TextBox2.Clear();
                        TextBox3.Clear();
                        TextBox4.Clear();
                        dataGridView1.DataSource = cargarequipomedicion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el equipo: {ex.Message}");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[EquipoPropositoPrueba] WHERE IDMaquinaria = @idmaquinaria;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@idmaquinaria", TextBox1.Text);
            try
            {
                cmd.ExecuteNonQuery();
                TextBox1.Clear();
                TextBox2.Clear();
                TextBox3.Clear();
                TextBox4.Clear();
                MessageBox.Show("Responsable eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar responsable: {ex.Message}");
            }
            dataGridView1.DataSource = cargarequipomedicion();
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

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox3.SelectedItem != null)
            {
                UnidadMedida unidadmedidaseleccionado = (UnidadMedida)ComboBox3.SelectedItem;
                int idSeleccionado = unidadmedidaseleccionado.IDUMedida;
                string nombreSeleccionado = unidadmedidaseleccionado.Nombre;
            }
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox4.SelectedItem != null)
            {
                UbicacionEquipo ubicacionequiposeleccionado = (UbicacionEquipo)ComboBox4.SelectedItem;
                int idSeleccionado = ubicacionequiposeleccionado.IDUbicacion;
                string nombreSeleccionado = ubicacionequiposeleccionado.Nombre;
            }
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox5.SelectedItem != null)
            {
                Responsable responsableseleccionado = (Responsable)ComboBox5.SelectedItem;
                int idSeleccionado = responsableseleccionado.IDResponsable;
                string nombreSeleccionado = responsableseleccionado.Nombre;
            }
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox6.SelectedItem != null)
            {
                Departamento departamentoseleccionado = (Departamento)ComboBox6.SelectedItem;
                int idSeleccionado = departamentoseleccionado.IDDepto;
                string nombreSeleccionado = departamentoseleccionado.Nombre;
            }
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string elementosMarcados = "";
            foreach (object item in CheckedListBox1.CheckedItems)
            {
                elementosMarcados += item.ToString() + ", ";
            }
            if (elementosMarcados.Length > 2)
            {
                elementosMarcados = elementosMarcados.Substring(0, elementosMarcados.Length - 2); // Elimina la última coma y espacio
            }
        }
    }
}
