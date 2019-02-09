using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class clsUsuario
    {
        private short _Codigo;//en la base de datos es smallint y equivale en c# a short

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private string _NombreUsuario;

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        private string _Clave;

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        public clsUsuario(short parCodigo, string parNombreUsuario, string parClave)
        {
            Codigo = parCodigo;
            NombreUsuario = parNombreUsuario;
            Clave = parClave;
        }
        public void Insertar()//los metodos tambien pueden tener sobrecarga
        {
            SqlConnection cn = new SqlConnection(mdlVariables.MiCadenaConexion);
            SqlCommand cmd = new SqlCommand("usp_Usuario_Insertar", cn);
        }

        public static clsUsuario ValidarCredenciales(string argUsuario, string argClave)
        {
            clsUsuario x = null;


            SqlConnection conexion;
            conexion = new SqlConnection(mdlVariables.MiCadenaConexion);

            SqlCommand MiComando;
            MiComando = new SqlCommand("usp_Usuario_Validar", conexion);
            MiComando.CommandType = System.Data.CommandType.StoredProcedure;
            MiComando.Parameters.AddWithValue("@parUsuario", argUsuario);
            MiComando.Parameters.AddWithValue("@parClave", argClave);

            conexion.Open();
            SqlDataReader contenedor;

            contenedor = MiComando.ExecuteReader();// este se usa para listar, al hacer Execute reader va a retornar la grilla de resultados de sql server que hace el procedimiento
            while (contenedor.Read() == true)//aqui tenemos el contenedor y con su metodo read(este recorrera la primera fila de la grilla que continene contenedor y si hay contenido en esa fila
            {
                x = new clsUsuario(short.Parse(contenedor["codigo"].ToString()), contenedor["usuario"].ToString(), "cualquier cosa");
            }

            conexion.Close();
            return x;
        }
    }
}
