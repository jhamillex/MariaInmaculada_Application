using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    class clsEspecialidad
    {
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public void Insertar(string parNombre)
        {


        }
        public DataTable listarEspecialidad()
        {
            DataTable tabla = new DataTable();
            SqlConnection ConexionListar = new SqlConnection(mdlVariables.MiCadenaConexion);
            SqlCommand ComandoListar = new SqlCommand("usp_Listar_Especialidad", ConexionListar);
            ComandoListar.CommandType = System.Data.CommandType.StoredProcedure;
            ConexionListar.Open();
            SqlDataReader leerFilas = ComandoListar.ExecuteReader();
            tabla.Load(leerFilas);
            leerFilas.Close();
            ConexionListar.Close();

            return tabla;
        }
    }
}
