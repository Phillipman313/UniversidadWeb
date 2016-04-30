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

    public partial class Periodo
    {
        public ICollection<Curso> Cursos { get; set; }
    }

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
}