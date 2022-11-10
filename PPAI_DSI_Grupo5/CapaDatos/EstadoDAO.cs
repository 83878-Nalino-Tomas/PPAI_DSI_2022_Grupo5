using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using PPAI_DSI_Grupo5.CapaDominio.FabricacionPura;
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
                Estado estado;
                var idEstado = int.Parse(res.Rows[i]["idEstado"].ToString());
                switch (idEstado)
                {
                    case 1:
                        estado = new DisponibleRT();
                        break;

                    case 2:
                        estado = new Pendiente();
                        break;

                    case 3:
                        estado = new Reservado();
                        break;

                    case 4:
                        estado = new Disponible();
                        break;

                    case 5:
                        estado = new EnMantenimiento();
                        break;

                    case 6:
                        estado = new MantenimientoCorrectivo();
                        break;

                    default:
                        estado = null;
                        break;
                }
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
                Estado estado;
                var idEstado = int.Parse(res.Rows[i]["idEstado"].ToString());
                switch (idEstado)
                {
                    case 1:
                        estado = new DisponibleRT();
                        break;

                    case 2:
                        estado = new Pendiente();
                        break;

                    case 3:
                        estado = new Reservado();
                        break;

                    case 4:
                        estado = new Disponible();
                        break;

                    case 5:
                        estado = new EnMantenimiento();
                        break;

                    case 6:
                        estado = new MantenimientoCorrectivo();
                        break;

                    default:
                        estado = null;
                        break;
                }
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
                Estado estado;
                var idEstado = int.Parse(res.Rows[i]["idEstado"].ToString());
                switch (idEstado)
                {
                    case 1:
                        estado = new DisponibleRT();
                        break;

                    case 2:
                        estado = new Pendiente();
                        break;

                    case 3:
                        estado = new Reservado();
                        break;

                    case 4:
                        estado = new Disponible();
                        break;

                    case 5:
                        estado = new EnMantenimiento();
                        break;

                    case 6:
                        estado = new MantenimientoCorrectivo();
                        break;

                    default:
                        estado = null;
                        break;
                }

                estado.idEstado = idEstado;
                estado.nombre = res.Rows[i]["nombre"].ToString();
                estado.descripcion = res.Rows[i]["descripcion"].ToString();
                estado.ambito = res.Rows[i]["ambito"].ToString();
                estados.Add(estado);
            }
            return estados;

        }
    }
}
