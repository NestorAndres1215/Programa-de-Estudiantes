using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Estudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conexion Exitosa");
            dataGridView1.DataSource = llenar_grid();
        }
        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            String consulta = "SELECT * FROM ALUMNO";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO ALUMNO (CODIGO,NOMBRES,APELLIDOS,DIRECCION)VALUES(@CODIGO,@NOMBRES,@APELLIDOS,@DIRECCION)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@CODIGO", txt_codigo.Text);
            cmd1.Parameters.AddWithValue("@NOMBRES", txt_alumno.Text);
            cmd1.Parameters.AddWithValue("@APELLIDOS", txt_apellido.Text);
            cmd1.Parameters.AddWithValue("@DIRECCION", txt_direccion.Text);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("DATOS FUERON GUARDADOS CON  EXITO");
            dataGridView1.DataSource = llenar_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE ALUMNO  SET CODIGO=@CODIGO,NOMBRES=@NOMBRES,APELLIDOS=@APELLIDOS,DIRECCION=@DIRECCION WHERE CODIGO=@CODIGO";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@CODIGO", txt_codigo.Text);
            cmd2.Parameters.AddWithValue("@NOMBRES", txt_alumno.Text);
            cmd2.Parameters.AddWithValue("@APELLIDOS", txt_apellido.Text);
            cmd2.Parameters.AddWithValue("@DIRECCION", txt_direccion.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("LOS DATOS SE HAN ACTUALIZADO");

            dataGridView1.DataSource = llenar_grid();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_codigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_alumno.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_apellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_direccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }

            catch { 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM ALUMNO WHERE CODIGO=@CODIGO";
            SqlCommand cm3 = new SqlCommand(eliminar, Conexion.Conectar());
            cm3.Parameters.AddWithValue("@CODIGO", txt_codigo.Text);
            cm3.ExecuteNonQuery();
            MessageBox.Show("LOS DATOS HAN SIDO ELIMINADOS");
            dataGridView1.DataSource = llenar_grid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_codigo.Clear();
            txt_alumno.Clear();
            txt_apellido.Clear();
            txt_direccion.Clear();

        }
    }
}
