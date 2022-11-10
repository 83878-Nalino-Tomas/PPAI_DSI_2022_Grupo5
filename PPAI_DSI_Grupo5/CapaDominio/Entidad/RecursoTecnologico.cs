using PPAI_DSI_Grupo5.CapaDatos;
using PPAI_DSI_Grupo5.CapaDominio.FabricacionPura;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class RecursoTecnologico
    {
        //ATRIBUTOS
        public int numeroRT { get; set; }
        public DateTime fechaAlta { get; set; }
        public string imagenes { get; set; }
        public int periodicidadManPrev { get; set; }
        public int duracionManPrev { get; set; }
        public int fraccionHorarioTurnos { get; set; }
        private List<CaracteristicaRecurso> caracteristicaRecurso { get; set; }
        public TipoRecursoTecnologico tipoRecurso { get; set; }
        public Modelo modeloDelRT { get; set; }
        private List<Mantenimiento> mantenimientos { get; set; }
        private List<HorarioRT> disponibilidad { get; set; }
        public List<CambioEstadoRT> cambioEstadoRT { get; set; }
        public List<Turno> turnos { get; set; }
        public CentroDeInvestigacion centroInvestigacion { get; set; }


        //METODOS

        // --> Metodo Constructor
        public RecursoTecnologico(int numeroRT, TipoRecursoTecnologico tipoRecurso, Modelo modeloDelRT, List<CambioEstadoRT> cambioEstadoRT, List<Turno> turnos)
        {
            this.numeroRT = numeroRT;
            this.tipoRecurso = tipoRecurso;
            this.modeloDelRT = modeloDelRT;
            this.cambioEstadoRT = cambioEstadoRT;
            this.turnos = turnos;
            
        }

        public RecursoTecnologico()
        {
        }

        // --> Retorna True si el tipoRecurso pasado como parametro coincide con el tipoRecurso de este Recurso
        public bool esTipoRecursoSeleccinado(string tipoRecurso)
        {
            return this.tipoRecurso.esSeleccionado(tipoRecurso);
        }

        // --> Retorna True si el estado actual del recurso admite reserva
        public bool esReservable()
        {
            return this.cambioEstadoRT.Last().esActual() && this.cambioEstadoRT.Last().esReservable();
        }

        // --> Retorna clase de fabricacion pura para los datos necesarios
        public RecursoTecnologicoMuestra mostrarDatosDeRT()
        {
            string nombreEstado = getEstadoRT();

            return new RecursoTecnologicoMuestra(centroInvestigacion, numeroRT, modeloDelRT.nombre, modeloDelRT.marca, nombreEstado);
        }

        // --> Retorna True si esta asignado y es activo
        public bool esCientificoDeMiCI(PersonalCientifico cientifico)
        {
            return centroInvestigacion.esCientificoActivo(cientifico);
        }

        // --> Obtencion de lista de turnos, diferenciando los turnos disponibles si es cientifico del centro o no
        public List<Turno> obtenerTurnos(bool esCientificodelCentro, DateTime date) 
        {
            List<Turno> turnosDisponibles = new List<Turno>();
            
            if (esCientificodelCentro)
            {
                foreach (Turno turno in turnos)
                    if (turno.validarFechaHoraInicio(date))
                    {

                        turnosDisponibles.Add(turno);
                    }
            }

            else
            {
                foreach (Turno turno in turnos)
                    // Se agrega el tiempo de antelacion de reserva
                    if (turno.validarFechaHoraInicio(date.AddDays(centroInvestigacion.getTiempoAntelacionReserva())))
                    {
                        turnosDisponibles.Add(turno);
                    }
            }

            return turnosDisponibles;
        }

        
        // --> Reserva un turno para un cientifico en un estado
        public void reservarTurno(Turno turnoSelecc, Estado est, PersonalCientifico cientifico)
        {
            turnoSelecc.reservar(est);
            centroInvestigacion.reservarTurnoCientifico(turnoSelecc, cientifico);
        }


        internal void asignarTurno(Turno turnoSeleccionado)
        {
            centroInvestigacion.asignarTurno(turnoSeleccionado);
        }

        // --> Getters&Setters
        public int getNumeroRT() { return numeroRT; }
        public string getTipoRecurso() { return tipoRecurso.getNombre(); }
        public string getCentro() { return centroInvestigacion.getNombre(); }
        public string getEstadoRT() { return cambioEstadoRT.Last<CambioEstadoRT>().getNombreEstado(); }

    }
}
