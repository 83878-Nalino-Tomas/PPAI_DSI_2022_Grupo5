using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDatos
{
    internal class PersonalCientificoDAO
    {
        internal static PersonalCientifico getCientifico(int legajo)
        {
            ConexionDb db = new ConexionDb();
            string sql = $"SELECT * FROM PersonalCientifico WHERE legajo = {legajo}";

            DataTable res = db.Query(sql);

            List<PersonalCientifico> cientificos = new List<PersonalCientifico>();

            for (int i = 0; i < res.Rows.Count; i++)
            {
                PersonalCientifico cientifico = new PersonalCientifico();
                cientifico.legajo = int.Parse(res.Rows[i]["legajo"].ToString());
                cientifico.correoPersonal = res.Rows[i]["correoPersonal"].ToString();
                cientificos.Add(cientifico);
            }
            return cientificos.First();
        }
    }
}
