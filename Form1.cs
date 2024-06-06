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

namespace BASE_DE_DATOS_ALUMNOS_UNI_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CONEXION.connectar();
            MessageBox.Show("Conexión exitosa");
            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM BASE1";
            SqlCommand cmd = new SqlCommand(consulta, CONEXION.connectar ());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CONEXION.connectar();
            string insertar = "INSERT INTO BASE1 (NUMERO_DE_CONTROL, NOMBRE, APELLIDO_MATERNO, APELLIDO_PATERNO, CARRERA) VALUES (@NUMERO_DE_CONTROL, @NOMBRE, @APELLIDO_MATERNO, @APELLIDO_PATERNO, @CARRERA)";
            SqlCommand cmd1 = new SqlCommand(insertar, CONEXION.connectar());
            cmd1.Parameters.AddWithValue("@NUMERO_DE_CONTROL", txtnumero.Text);
            cmd1.Parameters.AddWithValue("@NOMBRE", txtnombre.Text);
            cmd1.Parameters.AddWithValue("@APELLIDO_MATERNO", txtapellidomaterno.Text);
            cmd1.Parameters.AddWithValue("@APELLIDO_PATERNO", txtapellidopaterno.Text);
            cmd1.Parameters.AddWithValue("@CARRERA", txtcarrera.Text);
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados con éxito");
            dataGridView1.DataSource = llenar_grid();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                txtnumero.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtapellidomaterno.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtapellidopaterno.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtcarrera.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
            catch
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CONEXION.connectar();

            string actualizar = "UPDATE BASE1 SET NUMERO_DE_CONTROL=@NUMERO_DE_CONTROL, NOMBRE=@NOMBRE, APELLIDO_MATERNO=@APELLIDO_MATERNO, APELLIDO_PATERNO=@APELLIDO_PATERNO, CARRERA=@CARRERA WHERE NUMERO_DE_CONTROL = @NUMERO_DE_CONTROL";

            SqlCommand cmd2 = new SqlCommand(actualizar, CONEXION.connectar());

            cmd2.Parameters.AddWithValue("@NUMERO_DE_CONTROL", txtnumero.Text);
            cmd2.Parameters.AddWithValue("@NOMBRE", txtnombre.Text);
            cmd2.Parameters.AddWithValue("@APELLIDO_MATERNO", txtapellidomaterno.Text);
            cmd2.Parameters.AddWithValue("@APELLIDO_PATERNO", txtapellidopaterno.Text);
            cmd2.Parameters.AddWithValue("@CARRERA", txtcarrera.Text);
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados con éxito");
            dataGridView1.DataSource = llenar_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CONEXION.connectar();
            string eliminar = "DELETE FROM BASE1 WHERE NUMERO_DE_CONTROL=@NUMERO_DE_CONTROL";
            SqlCommand cmd3 = new SqlCommand(eliminar, CONEXION.connectar());
            cmd3.Parameters.AddWithValue("@NUMERO_DE_CONTROL", txtnumero.Text);
           
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron eliminados con éxito");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtnumero.Clear();
            txtnombre.Clear();
            txtapellidomaterno.Clear();
            txtapellidopaterno.Clear();
            txtcarrera.Clear();
            txtnumero.Focus();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
