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
    
    public partial class Universidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Universidad()
        {
            this.Sede = new HashSet<Sede>();
        }
    
        public int Id_Universidad { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sede> Sede { get; set; }
    }
}