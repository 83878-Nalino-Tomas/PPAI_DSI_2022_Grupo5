using PPAI_DSI_Grupo5.CapaDominio.FabricacionPura;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class Turno
    {
        //ATRIBUTOS
        public DateTime fechaGeneracion { get; set; }
        public DayOfWeek diaSemana { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public List<CambioEstadoTurno> cambioEstadoTurno { get; set; }

        // --> Metodo Constructor
        public Turno(DateTime fechaGeneracion, DayOfWeek diaSemana, DateTime fechaHoraInicio, DateTime fechaHoraFin, List<CambioEstadoTurno> cambioEstadoTurno)
        {
            this.fechaGeneracion = fechaGeneracion;
            this.diaSemana = diaSemana;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.cambioEstadoTurno = cambioEstadoTurno;
        }

        public Turno()
        {
        }

        //--> Validacion de si la fechaInicio del turno es posterior a la fecha pasada como parametro
        public bool validarFechaHoraInicio(DateTime timeInicio)
        {
            return this.fechaHoraInicio >= timeInicio;
        }

        //--> Retorna un modelo del turno para mostrar por pantalla
        public TurnoModel mostrarTurno()
        {
            return new TurnoModel(fechaHoraInicio, fechaHoraFin, cambioEstadoTurno.Last<CambioEstadoTurno>().Estado.getNombre());
        }

        //--> Se encarga de efectuar la reserva del turno
        public void reservar(Estado est)
        {
            cambioEstadoTurno.Last().FechaHoraHasta = DateTime.Now;

            var nuevoCambioEstado = new CambioEstadoTurno(this.fechaHoraInicio, est);

            cambioEstadoTurno.Add(nuevoCambioEstado);

        }

        // --> Getters&Setters
        public DateTime getfechaTurno()
        {
            return fechaHoraInicio;
        }
    }
}