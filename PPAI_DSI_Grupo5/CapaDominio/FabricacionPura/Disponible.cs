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
        internal override void reservarTurno(Turno turno)
        {
            CambioEstadoTurno cambioActual = new CambioEstadoTurno();
            var fecha = DateTime.Now;

            var cambios = turno.cambioEstadoTurno;
            
            foreach (var cambio in cambios)
            {
                if (cambio.esActual())
                {
                    cambio.fechaHoraHasta = fecha;
                    cambioActual = cambio;
                }
            }

            Reservado nuevoEstado = new Reservado();
            CambioEstadoTurno nuevoCambio = new CambioEstadoTurno(fecha);

            turno.estado = nuevoEstado;
            turno.cambioEstadoTurno.Add(nuevoCambio);

            CambioEstadoTurnoDAO.UpdateCambioTurno(turno, cambioActual);
            CambioEstadoTurnoDAO.InsertCambioTurno(turno, nuevoEstado);
        }

        public Disponible()
        {
            this.esDisponible = "ESTOY DISPONIBLE";
        }
    }
}
