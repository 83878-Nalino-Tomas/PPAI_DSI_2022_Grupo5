using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;

namespace PPAI_DSI_Grupo5.CapaDominio.FabricacionPura
{
    internal class Reservado : Estado
    {
        internal override void generarReservaRTSeleccionado(RecursoTecnologico recursoTecnologicoSeleccionado, Turno turnoSeleccionado)
        {
            throw new NotImplementedException();
        }

        public Reservado()
        {
            this.idEstado = 3;
        }
    }
}
