using System;
using System.Collections.Generic;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class CambioEstadoRT
    {
        //ATRIBUTOS
        public DateTime fechaHoraDesde { get; set; }
        public DateTime fechaHoraHasta { get; set; }
        public Estado estado { get; set; }

        public CambioEstadoRT()
        {
        }


        //METODOS

        // --> Metodo Constructor
        public CambioEstadoRT(DateTime fechaHoraDesde, DateTime fechaHoraHasta, Estado estado)
        {
            this.fechaHoraDesde = fechaHoraDesde;
            this.fechaHoraHasta = fechaHoraHasta;
            this.estado = estado;
        }

        // --> Devuelve si es actual
        public bool esActual()
        {
            return this.fechaHoraHasta.ToShortDateString() == "1/1/0001";
            if (this.fechaHoraDesde < DateTime.Now && DateTime.Now < this.fechaHoraHasta)
            {
                return true;
            }
            return false;
        }

        // --> Devuelve si el estado es RESERVABLE
        public bool esReservable()
        {
            return this.estado.esReservable();
        }

        // --> Getters&Setters
        public string getNombreEstado() { return estado.getNombre(); }
    }
}