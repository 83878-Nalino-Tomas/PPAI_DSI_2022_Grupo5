using System;
using System.Collections.Generic;

namespace PPAI_DSI_Grupo5.CapaDominio.Entidad
{
    public class AsignacionCientificoCI
    {
        //ATRIBUTOS
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public PersonalCientifico personalCientifico { get; set; }
        public List<Turno> turnos { get; set; }


        //METODOS

        // --> Metodo Constructor
        public AsignacionCientificoCI(DateTime fechaDesde, DateTime fechaHasta, PersonalCientifico personalCientifico)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.personalCientifico = personalCientifico;
            this.turnos = new List<Turno>();
        }

        public AsignacionCientificoCI()
        {
        }

        // --> Devuelve si el cientifico esta activo actualmente
        public bool esActivo(PersonalCientifico cientifico) { return (DateTime.Now > fechaDesde && DateTime.Now < fechaHasta); }

        public bool esCientificoActivo(PersonalCientifico cientifico) { return this.personalCientifico.legajo == cientifico.legajo; }

        // --> Añade un turno a la lista de turnos asignados a el cientifico
        public void setTurno(Turno turnoCorrespondiente) { turnos.Add(turnoCorrespondiente); }

        // --> Obtiene mail del cientifico
        public string obtenerMail(  PersonalCientifico cientifico )
        {
            return cientifico.getMail();
        }
    }
}