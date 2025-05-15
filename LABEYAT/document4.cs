using LABEYAT.src;
using LABEYAT.src.combobox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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

                ComboBox6.DataSource = listarresponsable;
                ComboBox6.ValueMember = "IDResponsable";
                ComboBox6.DisplayMember = "Nombre";
            }
            catch { }
        }

        private void LlenarComboBoxEstatus()
        {
            try
            {
                ComboBox5.Items.Clear();
                string query = "SELECT IDEstatus, Descripcion FROM [dbo].[Estatus];";
                SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
                SqlDataReader reader = cmd.ExecuteReader();

                var listareststus = new List<Estatus>();

                while (reader.Read())
                {
                    listareststus.Add(new Estatus(reader.GetInt32(0), reader.GetString(1)));
                }
                reader.Close();

                ComboBox5.DataSource = listareststus;
                ComboBox5.ValueMember = "IDEstatus";
                ComboBox5.DisplayMember = "Nombre";
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

        public DataTable equpomedicion()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT 
                em.Referencia,
                em.Nombre,
                m.Nombre AS Marca,
                mo.Descripcion AS Modelo,
                em.NumSerie,
                em.Imagen,
                em.Cantidad,
                um.Descripcion AS UnidadMedida,
                ue.Descripcion AS Ubicacion,
                r.Nombre AS Nombre,
                r.Apellido_Paterno AS ApellidoPaterno,
                r.Apellido_Materno AS ApellidoMaterno,
                es.Descripcion AS Estatus,
                em.EstadoUso,
                em.EstadoMtto
            FROM [dbo].[EquipoMedicion] em
            LEFT JOIN [dbo].[Marca] m ON em.IDMarca = m.IDMarca
            LEFT JOIN [dbo].[Modelo] mo ON em.IDModelo = mo.IDModelo
            LEFT JOIN [dbo].[UnidadMedida] um ON em.IDUMedida = um.IDUMedida
            LEFT JOIN [dbo].[UbicacionEquipo] ue ON em.IDUbicacion = ue.IDUbicacion
            LEFT JOIN [dbo].[Responsable] r ON em.IDResponsable = r.IDResponsable
            LEFT JOIN [dbo].[Estatus] es ON em.IDEstatus = es.IDEstatus;";
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
                LlenarComboBoxUnidaddeMedida();
                LlenarComboBoxUbicacion();
                LlenarComboBoxResponsable();
                LlenarComboBoxEstatus();
                LlenarComboBoxMantenimineto();
                LlenarComboBoxEstadoUso();
                LlenarCheckedListBoxNormas();
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
                    string query = "INSERT INTO [dbo].[EquipoMedicion] (Referencia, Nombre, IDMarca, IDModelo, NumSerie, Imagen, Cantidad, IDUMedida, IDUbicacion, IDResponsable, IDEstatus, EstadoUso, EstadoMtto) VALUES (@referencia, @nombre, @idmarca, @idmodelo, @numserie, @imagen, @cantidad, @idumedida, @idubicacion, @idresponsable, @idestatus, @estadouso, @estadomtto);";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@referencia", TextBox1.Text);
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
                        cmd.Parameters.AddWithValue("@imagen", TextBox6.Text);
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

                        if (ComboBox6.SelectedValue != null && int.TryParse(ComboBox6.SelectedValue.ToString(), out int idResponsableSeleccionado))
                        {
                            cmd.Parameters.Add("@idresponsable", SqlDbType.Int).Value = idResponsableSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox5.SelectedValue != null && int.TryParse(ComboBox5.SelectedValue.ToString(), out int idEstatusSeleccionado))
                        {
                            cmd.Parameters.Add("@idestatus", SqlDbType.Int).Value = idEstatusSeleccionado;
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
                        TextBox6.Clear();
                        dataGridView1.DataSource = equpomedicion();
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
            if (ComboBox3.SelectedItem != null)
            {
                UbicacionEquipo ubicacionequiposeleccionado = (UbicacionEquipo)ComboBox4.SelectedItem;
                int idSeleccionado = ubicacionequiposeleccionado.IDUbicacion;
                string nombreSeleccionado = ubicacionequiposeleccionado.Nombre;
            }
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox6.SelectedItem != null)
            { 
                Responsable responsableseleccionado = (Responsable)ComboBox6.SelectedItem;
                int idSeleccionado = responsableseleccionado.IDResponsable;
                string nombreSeleccionado = responsableseleccionado.Nombre;
            }
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox5.SelectedItem != null)
            {
                Estatus estatuseleccionado = (Estatus)ComboBox5.SelectedItem;
                int idSeleccionado = estatuseleccionado.IDEstatus;
                string nombreSeleccionado = estatuseleccionado.Nombre;
            }
        }

        private void ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Connectiondb.Conectar();
            string query = "DELETE FROM [dbo].[EquipoMedicion] WHERE Referencia = @referencia;";
            SqlCommand cmd = new SqlCommand(query, Connectiondb.Conectar());
            cmd.Parameters.AddWithValue("@referencia", TextBox1.Text);
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
            dataGridView1.DataSource = equpomedicion();
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
            TextBox6.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                TextBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                TextBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                TextBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                TextBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Connectiondb.Conectar())
                {
                    string query = "UPDATE EquipoMedicion SET Nombre = @nombre, IDMarca = @idmarca, IDModelo = @idmodelo, NumSerie = @numserie, Imagen = @imagen, Cantidad = @cantidad, IDUMedida = @idumedida, IDUbicacion = @idubicacion, IDResponsable = @idresponsable, IDEstatus = @idestatus, EstadoUso = @estadouso, EstadoMtto = @estadomtto WHERE @Referencia = Referencia";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@referencia", TextBox1.Text);
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
                        cmd.Parameters.AddWithValue("@imagen", TextBox6.Text);
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

                        if (ComboBox6.SelectedValue != null && int.TryParse(ComboBox6.SelectedValue.ToString(), out int idResponsableSeleccionado))
                        {
                            cmd.Parameters.Add("@idresponsable", SqlDbType.Int).Value = idResponsableSeleccionado;
                        }
                        else
                        {
                            return;
                        }

                        if (ComboBox5.SelectedValue != null && int.TryParse(ComboBox5.SelectedValue.ToString(), out int idEstatusSeleccionado))
                        {
                            cmd.Parameters.Add("@idestatus", SqlDbType.Int).Value = idEstatusSeleccionado;
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
                        TextBox6.Clear();
                        dataGridView1.DataSource = equpomedicion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el equipo: {ex.Message}");
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
