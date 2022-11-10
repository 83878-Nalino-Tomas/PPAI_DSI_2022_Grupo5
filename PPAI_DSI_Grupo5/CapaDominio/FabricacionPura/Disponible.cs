using PPAI_DSI_Grupo5.CapaDatos;
using PPAI_DSI_Grupo5.CapaDominio.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI_Grupo5.CapaDominio.FabricacionPura
{
    internal class Disponible:Estado
    {
        string esDisponible;
        internal override void generarReservaRTSeleccionado(RecursoTecnologico recursoTecnologicoSeleccionado, Turno turnoSeleccionado)
        {
            recursoTecnologicoSeleccionado.asignarTurno(turnoSeleccionado);
            var cambio = turnoSeleccionado.cambioEstadoTurno;
            CambioEstadoTurno cambioActual = new CambioEstadoTurno();
            foreach (var item in cambio)
            {
                if (item.esActual())
                {
                    cambioActual = item;
                }
            }
            var fecha = DateTime.Now;
            cambioActual.fechaHoraHasta = fecha;

            Estado nuevoEstado = new Reservado();
            CambioEstadoTurno nuevoCambio = new CambioEstadoTurno(fecha);

            turnoSeleccionado.estado = nuevoEstado;
            turnoSeleccionado.cambioEstadoTurno.Add(cambioActual);

            CambioEstadoDAO.UpdateCambioTurno(turnoSeleccionado, cambioActual);
            CambioEstadoDAO.InsertCambioTurno(turnoSeleccionado, nuevoEstado);
        }

        public Disponible()
        {
            this.esDisponible = "ESTOY DISPONIBLE";
        }
    }
}
