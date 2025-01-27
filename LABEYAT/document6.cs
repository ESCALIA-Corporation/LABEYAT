﻿using LABEYAT.src;
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
    }
}
