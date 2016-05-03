using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversidadWeb.Models
{
    [MetadataType(typeof(AnyoMetadata))]
    public partial class Anyo
    {

    }

    [MetadataType(typeof(PeriodoMetadata))]
    public partial class Periodo
    {
        public ICollection<Curso> Cursos { get; set; }
        private string periodoCompleto;

        public string PeriodoCompleto
        {
            get
            {
                return Orden + " " + Ciclo.Nombre + " " + Anyo.Anyo1 + " (" + FechaInicio + " - " + FechaFinal + ")";
            }
        }
    }

    [MetadataType(typeof(CursoLectivoMetadata))]
    public partial class CursoLectivo
    {
        private string horas;

        public string Horas
        {
            get
            {
                List<Horario> dias = Horario.Where(x => x.Id_CursoLectivoLF == Id_CursoLectivo).ToList<Horario>();
                int largo = dias.Count - 1;
                string horas = "";
                Horario parte = null;
                for (int i = 0; i < largo; i++)
                {
                    parte = dias.ElementAt(i);
                    horas += parte.HoraInicio + " - " + parte.HoraFin + " " + parte.DiaSemana.Codigo + "\n";
                }
                parte = dias.ElementAt(largo);
                horas += parte.HoraInicio + " - " + parte.HoraFin + " " + parte.DiaSemana.Codigo;
                return horas;
            }
        }
    }

    [MetadataType(typeof(Curso_EstudianteMetadata))]
    public partial class Curso_Estudiante
    {

    }

    public partial class Profesor
    {
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido1 + " " + Apellido2;
            }
        }
    }

    public partial class Estudiante
    {
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido1 + " " + Apellido2;
            }
        }
    }

    [MetadataType(typeof(MatriculaMetadata))]
    public partial class Matricula
    {

    }
}