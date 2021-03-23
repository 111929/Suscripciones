using EnCode.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace EnCode.Entidades
{
    public class Suscriptor
    {
        Conexion conexion = new Conexion();
        public int IdSuscriptor { get; set; }  
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NroDocumento { get; set; }
        public string TipoDocumento { get; set; } 
        public string Direccion { get; set; }    
        public string Telefono { get; set; }      
        public string Email { get; set; }
        public string NombreUsuario { get; set; }      
        public string Contraseña { get; set; }


        public void InsertarSuscripcion(Suscriptor suscriptor)
        {
            String nombreSP = "sp_InsertarSuscriptor";
            conexion.AbrirConexion();
            conexion.Comando.CommandType= CommandType.StoredProcedure;
            conexion.Comando.CommandText = nombreSP;
            conexion.Comando.Parameters.AddWithValue("@Nombre", suscriptor.Nombre);
            conexion.Comando.Parameters.AddWithValue("@Apellido", suscriptor.Apellido);
            conexion.Comando.Parameters.AddWithValue("@NroDocumento", suscriptor.NroDocumento);
            conexion.Comando.Parameters.AddWithValue("@TipoDocumento", suscriptor.TipoDocumento);
            conexion.Comando.Parameters.AddWithValue("@Direccion", suscriptor.Direccion);
            conexion.Comando.Parameters.AddWithValue("@Telefono", suscriptor.Telefono);
            conexion.Comando.Parameters.AddWithValue("@Email", suscriptor.Email);
            conexion.Comando.Parameters.AddWithValue("@NombreUsuario", suscriptor.NombreUsuario);
            conexion.Comando.Parameters.AddWithValue("@Contraseña", suscriptor.Contraseña);
            conexion.Comando.ExecuteNonQuery();
            conexion.Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EditarSuscriptor(Suscriptor suscriptor)
        {
            string nombreSP = "sp_EditarSuscriptor";
            conexion.AbrirConexion();
            
            conexion.Comando.CommandType = CommandType.StoredProcedure;
            conexion.Comando.CommandText = nombreSP;
            conexion.Comando.Parameters.AddWithValue("@Nombre", suscriptor.Nombre);
            conexion.Comando.Parameters.AddWithValue("@Apellido", suscriptor.Apellido);
            conexion.Comando.Parameters.AddWithValue("@NroDocumento", suscriptor.NroDocumento);
            conexion.Comando.Parameters.AddWithValue("@TipoDocumento", suscriptor.TipoDocumento);
            conexion.Comando.Parameters.AddWithValue("@Direccion", suscriptor.Direccion);
            conexion.Comando.Parameters.AddWithValue("@Telefono", suscriptor.Telefono);
            conexion.Comando.Parameters.AddWithValue("@Email", suscriptor.Email);
            conexion.Comando.Parameters.AddWithValue("@NombreUsuario", suscriptor.NombreUsuario);
            conexion.Comando.Parameters.AddWithValue("@Contraseña", suscriptor.Contraseña);
            conexion.Comando.ExecuteNonQuery();
            conexion.Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
    

}