using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    class clsAlumna
    {
        private string _DNI;

        public string DNI
        {
            get { return _DNI; }
            set { _DNI = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private string _ApPaterno;

        public string ApPaterno
        {
            get { return _ApPaterno; }
            set { _ApPaterno = value; }
        }
        private string _ApMaterno;

        public string ApMaterno
        {
            get { return _ApMaterno; }
            set { _ApMaterno = value; }
        }
        private DateTime _FechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }

        private byte _CodigoEspecialidad;

        public byte CodigoEspecialidad
        {
            get { return _CodigoEspecialidad; }
            set { _CodigoEspecialidad = value; }
        }

        private byte _CodigoGrado;

        public byte CodigoGrado
        {
            get { return _CodigoGrado; }
            set { _CodigoGrado = value; }
        }

        private byte _CodigoSeccion;

        public byte CodigoSeccion
        {
            get { return _CodigoSeccion; }
            set { _CodigoSeccion = value; }
        }


        ///////////////////////////////////////////////////////////////////
        //CONSTRUCTOR
        public clsAlumna(string argDNI, string argNombres, string argApPaterno, string argApMaterno, DateTime argFechaNAc, byte argCodigoEspecialidad, byte argCodigoGrado, byte argCodigoSeccion)
        {
            DNI = argDNI;
            Nombre = argNombres;
            ApPaterno = argApPaterno;
            ApMaterno = argApMaterno;
            FechaNacimiento = argFechaNAc;
            CodigoEspecialidad = argCodigoEspecialidad;
            CodigoGrado = argCodigoGrado;
            CodigoSeccion = argCodigoSeccion;

        }



        /////////////////////////////////////////////////////////////////

        public void Insertar()
        {
            SqlConnection ConexionInsertar = new SqlConnection(mdlVariables.MiCadenaConexion);
            SqlCommand ComandoInsertar = new SqlCommand("usp_insertar_alumno", ConexionInsertar);
            ComandoInsertar.CommandType = System.Data.CommandType.StoredProcedure;
            ConexionInsertar.Open();
            ComandoInsertar.Parameters.AddWithValue("@parDNI", DNI);
            ComandoInsertar.Parameters.AddWithValue("@parNombres", Nombre);
            ComandoInsertar.Parameters.AddWithValue("@parApPaterno", ApPaterno);
            ComandoInsertar.Parameters.AddWithValue("@parApMAterno", ApMaterno);
            ComandoInsertar.Parameters.AddWithValue("@parFecharNac", FechaNacimiento);
            ComandoInsertar.Parameters.AddWithValue("@parCodigoEspecialidad", CodigoEspecialidad);
            ComandoInsertar.Parameters.AddWithValue("@parCodigoGrado", CodigoGrado);
            ComandoInsertar.Parameters.AddWithValue("@parCodigoSeccion", CodigoSeccion);
            ComandoInsertar.ExecuteNonQuery();
            ConexionInsertar.Close();
        }
    }
}
