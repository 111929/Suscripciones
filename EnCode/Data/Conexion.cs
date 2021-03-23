using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace EnCode.Data
{
    public class Conexion
    {
        SqlConnection oConexion ;
        SqlCommand oComando;
        SqlDataReader oTabla = null;

        public Conexion()
        {
            oConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
            oComando = new SqlCommand();
        }
        public SqlCommand Comando{ get => oComando; set => oComando = value; }
        public SqlDataReader Tabla { get => oTabla; set => oTabla = value; }

        // Metodo para buscar subiscriptor     

        public void BuscarSuscriptor(string TipoDoc,int NroDocu)
        {
            string NombreSp = "sp_BuscarSuscriptor";
            oConexion.Open();
            Comando.Connection = oConexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = NombreSp;
            Comando.Parameters.AddWithValue("@NroDocumento",NroDocu);
            Comando.Parameters.AddWithValue("@TipoDocumento", TipoDoc);
            Tabla = Comando.ExecuteReader();
        }
        public DataTable VerificarSuscriptor(string TipoDoc, int NroDocu)
        {
            string NombreSp = "sp_VerificarSuscripcion";
            oConexion.Open();
            Comando.Connection = oConexion;
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.CommandText = NombreSp;
            DataTable Table = new DataTable();
            Comando.Parameters.AddWithValue("@NroDocumento", NroDocu);
            Comando.Parameters.AddWithValue("@TipoDocumento", TipoDoc);
            Table.Load(Comando.ExecuteReader());
            oConexion.Close();
            return Table;
            
        }
        
        public void AbrirConexion()
        {
            oConexion.Open();
            Comando.Connection = oConexion;
        }
       
        public void CerrarConexion()
        {
            oConexion.Close();
        }
    }
}