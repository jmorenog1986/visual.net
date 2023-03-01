using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Escritorio1._0
{
    public partial class Form1 : Form
    {
        SqlConnection conexion;

        

        public Form1()
        {
            InitializeComponent();
        }

        private void conectar()
        {
            conexion = new SqlConnection("Data Source=192.168.1.7;Initial Catalog=db01;Persist Security Info=True;User ID=SQLServer01;Password=123456");
            conexion.Open();

        }

        private void cerrarConexion()
        {
            conexion.Close();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO personas VALUES('" + txtDocumento.Text + "','" + txtNombre.Text + "','" + txtApellido.Text + "','" + txtEmail.Text + "')";
            acciones(sql);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            String sql = "UPDATE personas SET nombre='"+txtNombre.Text+"', apellido='"+txtApellido.Text+"', email='"+txtEmail.Text+"' WHERE documento='"+txtDocumento.Text+"'";
            acciones(sql);


        }
        private void acciones(String sql)
        {
            conectar();
            SqlCommand comando = new SqlCommand(sql, conexion);
            int b=comando.ExecuteNonQuery();
            if (b == 1)
            {
                MessageBox.Show("La operación se realizó con éxito.");
            }
            
            cerrarConexion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            String sql = "DELETE FROM personas  WHERE documento='" + txtDocumento.Text + "'";
            acciones(sql);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            String sql = "SELECT * FROM personas WHERE documento='" + txtDocumento.Text + "'";

            conectar();
            SqlCommand comando = new SqlCommand(sql,conexion);
            SqlDataReader datos=comando.ExecuteReader();
            while(datos.Read()){
                txtDocumento.Text = datos["documento"].ToString();
                txtNombre.Text = datos["nombre"].ToString();
                txtApellido.Text = datos["apellido"].ToString();
                txtEmail.Text = datos["email"].ToString();

            }
            cerrarConexion();
        }

        private void btnConsultarTodosUsuarios_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable("Personas");
            tabla.Columns.Add("Documento",typeof(int));
            tabla.Columns.Add("Nombre", typeof(String));
            tabla.Columns.Add("Apellido", typeof(String));
            tabla.Columns.Add("Email", typeof(String));


            String sql = "SELECT * FROM personas ";

            conectar();
            SqlCommand comando = new SqlCommand(sql, conexion);
            SqlDataReader datos = comando.ExecuteReader();
            while (datos.Read())
            {
                tabla.Rows.Add(
                        datos["documento"].ToString(),
                        datos["nombre"].ToString(),
                        datos["apellido"].ToString(),
                        datos["email"].ToString()

                    );

            }
            tablaUsuario.DataSource = tabla;
            cerrarConexion();
        }
    }
}
