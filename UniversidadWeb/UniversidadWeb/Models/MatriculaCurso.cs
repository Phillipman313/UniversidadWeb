//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversidadWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MatriculaCurso
    {
        public int Id_MatriculaCurso { get; set; }
        public int Id_Matricula { get; set; }
        public int Id_CursoLectivo { get; set; }
    
        public virtual Curso_Estudiante Curso_Estudiante { get; set; }
        public virtual Matricula Matricula { get; set; }
    }
}