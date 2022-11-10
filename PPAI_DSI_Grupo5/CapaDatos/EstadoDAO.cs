using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class EstadoDAO
    {
        internal static Estado getEstadoRT(string estadoSelec)
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Estado WHERE idEstado = {estadoSelec} AND ambito = 'RT'";

            DataTable res = db.Query(sql);

            List<Estado> estados = new List<Estado>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Estado estado = new Estado();
                estado.idEstado = int.Parse(res.Rows[i]["idEstado"].ToString());
                estado.nombre = res.Rows[i]["nombre"].ToString();
                estado.descripcion = res.Rows[i]["descripcion"].ToString();
                estado.ambito = res.Rows[i]["ambito"].ToString();
                estados.Add(estado);
            }
            return estados.First();

        }

        internal static Estado getEstadoTurno(string estadoSelec)
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Estado WHERE idEstado = {estadoSelec} AND ambito = 'Turno'";

            DataTable res = db.Query(sql);

            List<Estado> estados = new List<Estado>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Estado estado = new Estado();
                estado.idEstado = int.Parse(res.Rows[i]["idEstado"].ToString());
                estado.nombre = res.Rows[i]["nombre"].ToString();
                estado.descripcion = res.Rows[i]["descripcion"].ToString();
                estado.ambito = res.Rows[i]["ambito"].ToString();
                estados.Add(estado);
            }
            return estados.First();

        }

        internal static List<Estado> getEstados()
        {

            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Estado";

            DataTable res = db.Query(sql);

            List<Estado> estados = new List<Estado>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Estado estado = new Estado();
                estado.idEstado = int.Parse(res.Rows[i]["idEstado"].ToString());
                estado.nombre = res.Rows[i]["nombre"].ToString();
                estado.descripcion = res.Rows[i]["descripcion"].ToString();
                estado.ambito = res.Rows[i]["ambito"].ToString();
                estados.Add(estado);
            }
            return estados;

        }
    }
}
