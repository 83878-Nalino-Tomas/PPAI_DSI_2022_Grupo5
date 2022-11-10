using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class ModeloDAO
    {
        internal static Modelo getModelo(string nombre)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Modelo WHERE nombre = '{nombre}'";

            DataTable res = db.Query(sql);

            List<Modelo> modelos = new List<Modelo>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Modelo modelo = new Modelo();
                modelo.nombre = res.Rows[i]["nombre"].ToString();
                modelo.descripcion = res.Rows[i]["descripcion"].ToString();
                modelos.Add(modelo);
            }
            return modelos.First();
        }

        internal static List<Modelo> getModelosPorMarca(string marca)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM Modelo WHERE marca = '{marca}'";

            DataTable res = db.Query(sql);

            List<Modelo> modelos = new List<Modelo>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                Modelo modelo = new Modelo();
                modelo.nombre = res.Rows[i]["nombre"].ToString();
                modelo.descripcion = res.Rows[i]["descripcion"].ToString();
                modelos.Add(modelo);
            }
            return modelos;
        }
    }
}
