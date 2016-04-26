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
        private Horario horas;

        public Horario Horas
        {
            get
            {
                return Horario.Where(x => x.Id_CursoLectivoLF == Id_CursoLectivo).First();
            }
        }
    }
}