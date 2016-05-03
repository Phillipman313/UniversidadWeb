using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversidadWeb.Models
{
    public class AnyoMetadata
    {
        [Display(Name = "Año")]
        public string Anyo1;
    }

    public class PeriodoMetadata
    {
        [Display(Name = "Fecha inicio")]
        public DateTime FechaInicio;
        [Display(Name = "Fecha fin")]
        public DateTime FechaFinal;
        [Display(Name = "Tipo")]
        public Ciclo Ciclo;
        [Display(Name = "Sede")]
        public Sede Sede;
    }

    public class CursoLectivoMetadata
    {
        [Display(Name = "Nombre")]
        public string CursoLectivo1;
        [Display(Name = "Curso")]
        public Curso Curso;
        [Display(Name = "Periodo")]
        public Periodo Periodo;
        [Display(Name = "Profesor")]
        public Profesor Profesor;
        [Display(Name = "Horario")]
        public string Horas;
    }

    public class Curso_EstudianteMetadata
    {
        [Display(Name = "Grupo")]
        public CursoLectivo CursoLectivo;
        [Display(Name = "Estudiante")]
        public Estudiante Estudiante;
    }

    public class MatriculaMetadata
    {
        [Display(Name = "Codigo")]
        public string CodMatricula;
        [Display(Name = "Estudiante")]
        public Estudiante Estudiante;
        [Display(Name = "Periodo")]
        public Periodo Periodo;
    }
}