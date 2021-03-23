using EnCode.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EnCode.Entidades
{
    public class Suscripcion
    {
        Conexion conexion = new Conexion();
        public int IdAsociacion { get; set; }
        public int IdSuscriptor { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaFin { get; set; }
        public string MotivoFin { get; set; }

        public void AgregarSuscripcion(Suscripcion suscripcion)
        {
            String nombreSP = "sp_AgregarSuscripcion";
            conexion.AbrirConexion();
            conexion.Comando.CommandType = CommandType.StoredProcedure;
            conexion.Comando.CommandText = nombreSP;
            conexion.Comando.Parameters.AddWithValue("@IdSuscriptor", suscripcion.IdSuscriptor);
            conexion.Comando.Parameters.AddWithValue("@FechaAlta", suscripcion.FechaAlta);
            conexion.Comando.Parameters.AddWithValue("@FechaFin", suscripcion.FechaFin);
            conexion.Comando.Parameters.AddWithValue("@MotivoFin", suscripcion.MotivoFin);
            conexion.Comando.ExecuteNonQuery();
            conexion.Comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }


}