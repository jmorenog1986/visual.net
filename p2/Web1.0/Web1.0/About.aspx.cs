using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Web1._0
{
    public partial class About : Page
    {

        SqlConnection conexion;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BtnGuardar_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO personas VALUES('" + txtDocumento.Text + "','" + txtNombre.Text + "','" + txtApellido.Text + "','" + txtEmail.Text + "')";
            Acciones(sql);

        }



        public void Conectar()
        {
            conexion = new SqlConnection("Data Source=192.168.1.7;Initial Catalog=db01;Persist Security Info=True;User ID=SQLServer01;Password=123456");
            conexion.Open();

        }

        public void CerrarConexion()
        {
            conexion.Close();
        }



        public void BtnActualizar_Click(object sender, EventArgs e)
        {

            String sql = "UPDATE personas SET nombre='" + txtNombre.Text + "', apellido='" + txtApellido.Text + "', email='" + txtEmail.Text + "' WHERE documento='" + txtDocumento.Text + "'";
            Acciones(sql);


        }
        public void Acciones(String sql)
        {
            Conectar();
            SqlCommand comando = new SqlCommand(sql, conexion);
            int b = comando.ExecuteNonQuery();
            if (b == 1)
            {
                
            }

            CerrarConexion();
        }

        public void BtnEliminar_Click(object sender, EventArgs e)
        {

            String sql = "DELETE FROM personas  WHERE documento='" + txtDocumento.Text + "'";
            Acciones(sql);
        }

    }
}